/* 
 * Forge SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Design Automation
 *
 * Generated by [Forge Swagger Codegen](https://git.autodesk.com/forge-ozone/forge-rsdk-codegen)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Autodesk.Forge.Core;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using Autodesk.Forge.DesignAutomation.Rsdk.Model;

namespace Autodesk.Forge.DesignAutomation.Rsdk.Http
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IForgeAppsApi
    {
        /// <summary>
        /// Creates/updates the nickname for the current Forge app. Creates/updates the nickname for the current Forge app.  The nickname is  used as a clearer alternative name when identifying AppBundles and Activities, as  compared to using the Forge app ID.  Once you have defined a nickname,  it MUST be used instead of the Forge app ID.                The new nickname cannot be in use by any other Forge app.                The Forge app cannot have any data when this endpoint is invoked.  Use the &#39;DELETE /forgeapps/me&#39;  endpoint (cautiously!!!) to remove all data from this Forge app.  &#39;DELETE /forgeapps/me&#39; is  also the only way to remove the nickname.                Note the nickname is supplied in the body, not as a query-parameter.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Must be \&quot;me\&quot; for the call to succeed.</param>/// <param name="nicknameRecord">new nickname (public key is for internal use only).</param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> CreateNicknameAsync (string id, NicknameRecord nicknameRecord, string scopes = null, IDictionary<string, string> headers = null, bool throwOnError = true);
        /// <summary>
        /// Delete all data associated with this Forge app. Delete all data associated with the given Forge app.                ALL Design Automation appbundles and activities are DELETED.                This action is required prior to using the &#39;PATCH /forgeapps/me&#39; endpoint when changing the nickname for the current Forge app,.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Must be \&quot;me\&quot; for the call to succeed.</param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> DeleteForgeAppAsync (string id, string scopes = null, IDictionary<string, string> headers = null, bool throwOnError = true);
        /// <summary>
        /// Returns the user&#39;s (app) nickname. Return the given Forge app&#39;s nickname.                If the app has no nickname, this route will return its id.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Must be \&quot;me\&quot; for the call to succeed.</param>
        /// <returns>Task of ApiResponse<string></returns>
        
        System.Threading.Tasks.Task<ApiResponse<string>> GetNicknameAsync (string id, string scopes = null, IDictionary<string, string> headers = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ForgeAppsApi : IForgeAppsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForgeAppsApi"/> class
        /// using ForgeService object
        /// </summary>
        /// <param name="service">An instance of ForgeService</param>
        /// <returns></returns>
        public ForgeAppsApi(ForgeService service = null, IOptions<Configuration> configuration = null)
        {
            this.Service = service ?? ForgeService.CreateDefault();

            // set BaseAddress from configuration or default
            this.Service.Client.BaseAddress = configuration?.Value.BaseAddress ?? new Configuration().BaseAddress;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the ForgeService</value>
        public ForgeService Service {get; set;}

        /// <summary>
        /// Creates/updates the nickname for the current Forge app. Creates/updates the nickname for the current Forge app.  The nickname is  used as a clearer alternative name when identifying AppBundles and Activities, as  compared to using the Forge app ID.  Once you have defined a nickname,  it MUST be used instead of the Forge app ID.                The new nickname cannot be in use by any other Forge app.                The Forge app cannot have any data when this endpoint is invoked.  Use the &#39;DELETE /forgeapps/me&#39;  endpoint (cautiously!!!) to remove all data from this Forge app.  &#39;DELETE /forgeapps/me&#39; is  also the only way to remove the nickname.                Note the nickname is supplied in the body, not as a query-parameter.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Must be \&quot;me\&quot; for the call to succeed.</param>/// <param name="nicknameRecord">new nickname (public key is for internal use only).</param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> CreateNicknameAsync (string id, NicknameRecord nicknameRecord, string scopes = null, IDictionary<string, string> headers = null, bool throwOnError = true)
        {
            using (var request = new HttpRequestMessage())
            {
                request.RequestUri = 
                    Marshalling.BuildRequestUri("/v3/forgeapps/{id}", 
                        routeParameters: new Dictionary<string, object> {
                            { "id", id},
                        },
                        queryParameters: new Dictionary<string, object> {
                        }
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                if (headers!=null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.TryAddWithoutValidation(header.Key, header.Value);
                    }
                }

                request.Content = Marshalling.Serialize(nicknameRecord); // http body (model) parameter

                // tell the underlying pipeline what scope we'd like to use
                if (scopes == null)
                {
                    request.Properties.Add(ForgeConfiguration.ScopeKey, "code:all");
                }
                else
                {
                    request.Properties.Add(ForgeConfiguration.ScopeKey, scopes);
                }

                request.Method = new HttpMethod("PATCH");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    await response.EnsureSuccessStatusCodeAsync();
                }
                else if (!response.IsSuccessStatusCode)
                {
                    return response;
                }

                return response;

            } // using
        }
        /// <summary>
        /// Delete all data associated with this Forge app. Delete all data associated with the given Forge app.                ALL Design Automation appbundles and activities are DELETED.                This action is required prior to using the &#39;PATCH /forgeapps/me&#39; endpoint when changing the nickname for the current Forge app,.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Must be \&quot;me\&quot; for the call to succeed.</param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteForgeAppAsync (string id, string scopes = null, IDictionary<string, string> headers = null, bool throwOnError = true)
        {
            using (var request = new HttpRequestMessage())
            {
                request.RequestUri = 
                    Marshalling.BuildRequestUri("/v3/forgeapps/{id}", 
                        routeParameters: new Dictionary<string, object> {
                            { "id", id},
                        },
                        queryParameters: new Dictionary<string, object> {
                        }
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                if (headers!=null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.TryAddWithoutValidation(header.Key, header.Value);
                    }
                }


                // tell the underlying pipeline what scope we'd like to use
                if (scopes == null)
                {
                    request.Properties.Add(ForgeConfiguration.ScopeKey, "code:all");
                }
                else
                {
                    request.Properties.Add(ForgeConfiguration.ScopeKey, scopes);
                }

                request.Method = new HttpMethod("DELETE");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    await response.EnsureSuccessStatusCodeAsync();
                }
                else if (!response.IsSuccessStatusCode)
                {
                    return response;
                }

                return response;

            } // using
        }
        /// <summary>
        /// Returns the user&#39;s (app) nickname. Return the given Forge app&#39;s nickname.                If the app has no nickname, this route will return its id.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Must be \&quot;me\&quot; for the call to succeed.</param>
        /// <returns>Task of ApiResponse<string></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<string>> GetNicknameAsync (string id, string scopes = null, IDictionary<string, string> headers = null, bool throwOnError = true)
        {
            using (var request = new HttpRequestMessage())
            {
                request.RequestUri = 
                    Marshalling.BuildRequestUri("/v3/forgeapps/{id}", 
                        routeParameters: new Dictionary<string, object> {
                            { "id", id},
                        },
                        queryParameters: new Dictionary<string, object> {
                        }
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                if (headers!=null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.TryAddWithoutValidation(header.Key, header.Value);
                    }
                }


                // tell the underlying pipeline what scope we'd like to use
                if (scopes == null)
                {
                    request.Properties.Add(ForgeConfiguration.ScopeKey, "code:all");
                }
                else
                {
                    request.Properties.Add(ForgeConfiguration.ScopeKey, scopes);
                }

                request.Method = new HttpMethod("GET");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    await response.EnsureSuccessStatusCodeAsync();
                }
                else if (!response.IsSuccessStatusCode)
                {
                    return new ApiResponse<string>(response, default(string));
                }

                return new ApiResponse<string>(response, await Marshalling.DeserializeAsync<string>(response.Content));

            } // using
        }
    }
}
