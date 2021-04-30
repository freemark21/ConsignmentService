using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Client;

namespace ConsignmentService
{
    public class APIhelper
    {

        public static HttpClient APIclient { get; set; }

        public static void Initialize()
        {
            APIclient = new HttpClient();
            APIclient.DefaultRequestHeaders.Accept.Clear();
            APIclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static TokenResponse RequestToken(OAuth2Client oAuth2, string serviceAccountAccessKey, string serviceAccountSecretKey)
        {
            return oAuth2.RequestResourceOwnerPasswordAsync
                (serviceAccountAccessKey, serviceAccountSecretKey).Result;
        }

        public static TokenResponse RefreshToken(OAuth2Client oAuth2, string refreshToken)
        {
            return oAuth2.RequestRefreshTokenAsync(refreshToken).Result;
        }

        public static async Task<Ttblsastaz> GetShipTo(TokenResponse token, string cono, string customerNumber, string userID, Uri uri)
        {
            var quote = "\"";
            string fetchWhereQuery = $"{{\r\n  {quote}CompanyNumber{quote}: 1,\r\n  {quote}Operator{quote}: {quote}sys{quote},\r\n  {quote}TableName{quote}: {quote}sastaz{quote},\r\n  {quote}WhereClause{quote}: {quote}sastaz.cono= {cono} and sastaz.codeiden='SupplyPro Dept OEEBB' and primarykey='{customerNumber}' and secondarykey='{userID}'{quote},\r\n  {quote}BatchSize{quote}: 1\r\n}}";
            var content = new StringContent(fetchWhereQuery, Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await APIclient.PostAsync(uri, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    Rootobject rootobject = await response.Content.ReadAsAsync<Rootobject>();
                    if (rootobject.Ttblsastaz is null)
                    {
                        return null;
                    }
                    Ttblsastaz ttblsastaz = rootobject.Ttblsastaz[0];
                    return ttblsastaz;

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
