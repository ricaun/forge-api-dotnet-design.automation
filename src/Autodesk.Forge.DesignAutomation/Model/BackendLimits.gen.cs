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
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Autodesk.Forge.DesignAutomation.Model
{
    /// <summary>
    /// BackendLimits
    /// </summary>
    [DataContract]
    public partial class BackendLimits 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BackendLimits" /> class.
        /// </summary>
        public BackendLimits()
        {
        }
        
        /// <summary>
        /// Gets or Sets LimitDownloads
        /// </summary>
        [DataMember(Name="limitDownloads", EmitDefaultValue=false)]
        public int LimitDownloads { get; set; }

        /// <summary>
        /// Gets or Sets LimitUploads
        /// </summary>
        [DataMember(Name="limitUploads", EmitDefaultValue=false)]
        public int LimitUploads { get; set; }

        /// <summary>
        /// Gets or Sets LimitDownloadSizeMB
        /// </summary>
        [DataMember(Name="limitDownloadSizeMB", EmitDefaultValue=false)]
        public int LimitDownloadSizeMB { get; set; }

        /// <summary>
        /// Gets or Sets LimitUploadSizeMB
        /// </summary>
        [DataMember(Name="limitUploadSizeMB", EmitDefaultValue=false)]
        public int LimitUploadSizeMB { get; set; }

        /// <summary>
        /// Gets or Sets LimitProcessingTimeSec
        /// </summary>
        [DataMember(Name="limitProcessingTimeSec", EmitDefaultValue=false)]
        public int LimitProcessingTimeSec { get; set; }

        /// <summary>
        /// Gets or Sets LimitTotalUncompressedAppsSizeInMB
        /// </summary>
        [DataMember(Name="limitTotalUncompressedAppsSizeInMB", EmitDefaultValue=false)]
        public int LimitTotalUncompressedAppsSizeInMB { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

}
