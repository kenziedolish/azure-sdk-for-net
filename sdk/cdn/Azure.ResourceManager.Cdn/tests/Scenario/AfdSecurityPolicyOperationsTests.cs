﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class AfdSecurityPolicyOperationsTests : CdnManagementTestBase
    {
        public AfdSecurityPolicyOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfile = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AfdEndpointResource afdEndpointInstance = await CreateAfdEndpoint(afdProfile, afdEndpointName);
            string afdSecurityPolicyName = Recording.GenerateAssetName("AFDSecurityPolicy-");
            AfdSecurityPolicyResource afdSecurityPolicy = await CreateAfdSecurityPolicy(afdProfile, afdEndpointInstance, afdSecurityPolicyName);
            await afdSecurityPolicy.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await afdSecurityPolicy.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfile = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdEndpointName1 = Recording.GenerateAssetName("AFDEndpoint-");
            AfdEndpointResource afdEndpointInstance1 = await CreateAfdEndpoint(afdProfile, afdEndpointName1);
            string afdSecurityPolicyName = Recording.GenerateAssetName("AFDSecurityPolicy-");
            AfdSecurityPolicyResource afdSecurityPolicy = await CreateAfdSecurityPolicy(afdProfile, afdEndpointInstance1, afdSecurityPolicyName);
            string afdEndpointName2 = Recording.GenerateAssetName("AFDEndpoint-");
            AfdEndpointResource afdEndpointInstance2 = await CreateAfdEndpoint(afdProfile, afdEndpointName2);
            PatchableAfdSecurityPolicyData updateOptions = new PatchableAfdSecurityPolicyData
            {
                Parameters = new SecurityPolicyWebApplicationFirewallParameters
                {
                    WafPolicy = new WritableSubResource
                    {
                        Id = new ResourceIdentifier("/subscriptions/f3d94233-a9aa-4241-ac82-2dfb63ce637a/resourceGroups/CdnTest/providers/Microsoft.Network/frontdoorWebApplicationFirewallPolicies/testAFDWaf")
                    }
                }
            };
            SecurityPolicyWebApplicationFirewallAssociation securityPolicyWebApplicationFirewallAssociation = new SecurityPolicyWebApplicationFirewallAssociation();
            securityPolicyWebApplicationFirewallAssociation.Domains.Add(new ActivatedResourceReference
            {
                Id = afdEndpointInstance1.Id
            });
            securityPolicyWebApplicationFirewallAssociation.Domains.Add(new ActivatedResourceReference
            {
                Id = afdEndpointInstance2.Id
            });
            securityPolicyWebApplicationFirewallAssociation.PatternsToMatch.Add("/*");
            ((SecurityPolicyWebApplicationFirewallParameters)updateOptions.Parameters).Associations.Add(securityPolicyWebApplicationFirewallAssociation);
            var lro = await afdSecurityPolicy.UpdateAsync(WaitUntil.Completed, updateOptions);
            AfdSecurityPolicyResource updatedSecurityPolicy = lro.Value;
            ResourceDataHelper.AssertAfdSecurityPolicyUpdate(updatedSecurityPolicy, updateOptions);
        }
    }
}
