using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Client;

namespace ConsignmentService
{
    public class Worker : BackgroundService
    {
        private readonly string watchPath;
        private static OAuth2Client oAuth2Client;
        private readonly ILogger<Worker> _logger;


        public Worker(ILogger<Worker> logger)
        {
            watchPath = @"C:\test\supplypro";
            _logger = logger;
            
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }


        private void Watch(string path)
        {
            //initialize
            FileSystemWatcher watcher = new FileSystemWatcher
            {

                //assign paramater path
                Path = path,

                //don't watch subdirectories
                IncludeSubdirectories = false
            };

            //file created event
            watcher.Created += FileSystemWatcher_Created;

            //filters
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Size | NotifyFilters.Attributes;

            //only look for csv
            watcher.Filter = "*.csv";

            // Begin watching.
            watcher.EnableRaisingEvents = true;

        }
        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            _logger.LogInformation($"{e.Name} has been created");
            Thread.Sleep(5000);
            while (!IsFileLocked(e.FullPath))
            {
                ReadWriteStream(e.FullPath, e.Name);
                break;
            }
        }

        private static bool IsFileLocked(string filePath)
        {
            try
            {
                using FileStream originalFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                originalFileStream.Close();
            }
            catch (Exception)
            {
                return true;
            }
            return false;
        }

        private void ReadWriteStream(string path, string fileName)
        {

            string customerNumber = null;
            string cono = null;
            string originalPath = path;
            string destinationPath = path.Replace(@"\supplypro\", @"\ftpuser\");
            var lineCount = File.ReadLines(path).Count();

            if (lineCount > 1)
            {
                using FileStream originalFileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                using StreamReader streamReader = new StreamReader(originalFileStream);
                using FileStream destinationFileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write);
                using StreamWriter streamWriter = new StreamWriter(destinationFileStream);
                DataAccess dataAccess = new DataAccess();
                oAuth2Client = new OAuth2Client(new Uri(OAuth2TokenEndpoint), ResourceOwnerClientId, ResourceOwnerClientSecret);
                TokenResponse token = APIhelper.RequestToken(oAuth2Client, ServiceAccountAccessKey, ServiceAccountSecretKey);
                if (!token.IsError)
                {
                    APIhelper.APIclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
                }
                try
                {
                    string[] lines = File.ReadAllLines(path);

                    foreach (string line in lines)
                    {
                        string[] col = line.Split('|');
                        if (col[0] != "" && col[0].ToUpper() != "DEPARTMENT")
                        {
                            string[] departmentField = col[0].Split('-');
                            customerNumber = departmentField[1];
                            cono = departmentField[3];
                            break;
                        }
                    }


                    foreach (string line in lines)
                    {
                        string[] col = line.Split('|');
                        bool success = Int32.TryParse(col[17], out int quantity);
                        if (col[4].ToUpper() == "RETURN")
                        {
                            if (success)
                            {
                                quantity *= -1;
                                string[] device = col[34].Split("-");
                                ReturnItem returnItem = new ReturnItem();
                                returnItem.CustomerNumber = customerNumber;
                                returnItem.UserID = col[10];
                                returnItem.Cono = cono;
                                returnItem.Whse = device[0];
                                returnItem.ReplenexNumber = col[24];
                                returnItem.Qty = quantity;
                                returnItem.UnitOfIssue = col[38];
                                returnItem.SupplyProPrice = col[20];
                                returnItem.ProductName = col[5];
                                string[] deptSplit = col[0].Split('-');
                                returnItem.ShipTo = deptSplit[2];
                                if (!token.IsError)
                                {
                                    Task<Ttblarss> ttblarss = APIhelper.GetShipToWhse(token, cono, customerNumber, returnItem.ShipTo, FetchWhere);
                                    if (ttblarss.Result.whse != null)
                                    {
                                        returnItem.ShipToWhse = ttblarss.Result.whse;
                                    }
                                }
                                try
                                {

                                    dataAccess.InsertReturnItem(returnItem);
                                }
                                catch (Exception e)
                                {
                                    _logger.LogError($" failed to write {line} {Environment.NewLine} filename: {fileName} {Environment.NewLine} error: {e}");
                                }
                                continue;
                            }
                        }

                        if (col[0] == "")
                        {
                            if (col[9] != "REPLENEX ADMIN")
                            {
                                if (success)
                                {

                                    if (quantity < 0)
                                    {
                                        string[] device = col[34].Split("-");
                                        ReturnItem returnItem = new ReturnItem();
                                        returnItem.CustomerNumber = customerNumber;
                                        returnItem.UserID = col[10];
                                        returnItem.Cono = cono;
                                        returnItem.Whse = device[0];
                                        returnItem.ReplenexNumber = col[24];
                                        returnItem.Qty = quantity;
                                        returnItem.UnitOfIssue = col[38];
                                        returnItem.SupplyProPrice = col[20];
                                        returnItem.ProductName = col[5];
                                        if (!token.IsError)
                                        {
                                            Task<Ttblsastaz> ttblsastaz =  APIhelper.GetShipTo(token, cono, customerNumber, returnItem.UserID, FetchWhere);
                                            if (ttblsastaz.Result.Codeval[0] != "")
                                            {
                                                returnItem.ShipTo = ttblsastaz.Result.Codeval[0];
                                            }
                                            Task<Ttblarss> ttblarss = APIhelper.GetShipToWhse(token, cono, customerNumber, returnItem.ShipTo, FetchWhere);
                                            if (ttblarss.Result.whse != null)
                                            {
                                                returnItem.ShipToWhse = ttblarss.Result.whse;
                                            }
                                        }
                                        try
                                        {
                                            dataAccess.InsertReturnItem(returnItem);
                                        }
                                        catch (Exception e)
                                        {
                                            _logger.LogError($" failed to write {line} {Environment.NewLine} filename: {fileName} {Environment.NewLine} error: {e}");
                                        }
                                        continue;
                                    }
                                }
                                else
                                {
                                    _logger.LogError($"Could not parse quantity {col[17]}, from {fileName}. Line {line}");
                                }
                            }
                        }
                        streamWriter.WriteLine($"{line}");
                    }

                    streamReader.Close();
                    streamWriter.Close();

                    //archive path
                    string archivePath = path.Replace(fileName, @"archive\" + fileName);

                    //move to archive path
                    while (!IsFileLocked(originalPath))
                    {
                        try
                        {
                            File.Move(originalPath, archivePath, true);
                            break;
                        }
                        catch (Exception e)
                        {
                            _logger.LogError($"Unable to move {fileName} to archive. Error: {e}");
                            break;
                        }
                    }


                }
                catch (Exception e)
                {
                    //error path
                    string errorPath = path.Replace(fileName, @"error\" + fileName);
                    streamReader.Close();
                    streamWriter.Close();
                    //move to error path
                    while (!IsFileLocked(originalPath))
                    {
                        File.Move(path, errorPath);
                        _logger.LogError($"{fileName} was moved to Error folder. Error: {e}");
                        break;
                    }

                }
                finally
                {
                    destinationFileStream.Close();
                    originalFileStream.Close();

                }
            }
            else
            {
                File.Delete(path);
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                APIhelper.Initialize();
                Watch(watchPath);
                _logger.LogInformation("conissu being watched");
                await Task.Delay(Timeout.Infinite, stoppingToken);
            }
            catch (Exception e)
            {

                _logger.LogInformation($"service was stopped error: {e} ");

            }
        }
    }
}
