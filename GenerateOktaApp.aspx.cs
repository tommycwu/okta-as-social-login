using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace OktaSocialLogin
{
    public partial class GenerateOktaApp : System.Web.UI.Page
    {
        private static string gApiKey = "00hq5_z3_oDenHOD_aHCBGtwGIVZ896z23oT9VC0dp";
        private static string gApiUrl = "https://dev-8964037.okta.com/api/v1/apps/";
        private string PostWithData(string fullUrl, string apiKey, string postData)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri(fullUrl)
                    };
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    request.Headers.Authorization = new AuthenticationHeaderValue("SSWS", apiKey);
                    request.Content = new StringContent(postData, Encoding.UTF8, "application/json");
                    var response = client.SendAsync(request);
                    return response.Result.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private string PutWithoutData(string fullUrl, string apiKey)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Put,
                        RequestUri = new Uri(fullUrl)
                    };
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    request.Headers.Authorization = new AuthenticationHeaderValue("SSWS", apiKey);
                    var response = client.SendAsync(request);
                    var retResult = response.Status;
                    return response.Result.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string partData1 = "{\"name\": \"oidc_client\",\"label\": \"" + TextBox1.Text;
                string partData2 = "\",\"signOnMode\": \"OPENID_CONNECT\",\"settings\": {\"oauthClient\": {\"redirect_uris\": [\"";
                string partData3 = TextBox2.Text;
                string partData4 = "\"],\"response_types\": [\"token\",\"id_token\",\"code\"],\"grant_types\": [\"implicit\",\"authorization_code\"],\"application_type\": \"web\"}}}";
                string concatParts = partData1 + partData2 + partData3 + partData4;
                var resultJson = PostWithData(gApiUrl, gApiKey, concatParts);
                dynamic resultObj = JsonConvert.DeserializeObject(resultJson);
                TextBox3.Text = resultObj.credentials.oauthClient.client_id;
                TextBox4.Text = resultObj.credentials.oauthClient.client_secret;

                var appId = resultObj.id;
                var assignUrl = gApiUrl + appId + "/groups/" + "00ggninxK7cj2eK0Z5d5";
                PutWithoutData(assignUrl, gApiKey);
            }
            catch (Exception ex)
            {
                TextBox4.Text = ex.Message;
            }

        }
    }
}