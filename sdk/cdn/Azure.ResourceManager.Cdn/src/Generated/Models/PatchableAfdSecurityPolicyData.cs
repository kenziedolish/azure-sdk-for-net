// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The JSON object containing security policy update parameters. </summary>
    public partial class PatchableAfdSecurityPolicyData
    {
        /// <summary> Initializes a new instance of PatchableAfdSecurityPolicyData. </summary>
        public PatchableAfdSecurityPolicyData()
        {
        }

        /// <summary> object which contains security policy parameters. </summary>
        internal SecurityPolicyPropertiesParameters Parameters { get; set; }
        /// <summary> The type of the Security policy to create. </summary>
        internal SecurityPolicyType ParametersPolicyType
        {
            get => Parameters is null ? default : Parameters.PolicyType;
            set
            {
                if (Parameters is null)
                    Parameters = new SecurityPolicyPropertiesParameters();
                Parameters.PolicyType = value;
            }
        }
    }
}
