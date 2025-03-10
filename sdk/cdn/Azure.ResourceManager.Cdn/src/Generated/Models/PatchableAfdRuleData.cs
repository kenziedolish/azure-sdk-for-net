// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The domain JSON object required for domain creation or update. </summary>
    public partial class PatchableAfdRuleData
    {
        /// <summary> Initializes a new instance of PatchableAfdRuleData. </summary>
        public PatchableAfdRuleData()
        {
            Conditions = new ChangeTrackingList<DeliveryRuleCondition>();
            Actions = new ChangeTrackingList<DeliveryRuleAction>();
        }

        /// <summary> The name of the rule set containing the rule. </summary>
        public string RuleSetName { get; }
        /// <summary> The order in which the rules are applied for the endpoint. Possible values {0,1,2,3,………}. A rule with a lesser order will be applied before a rule with a greater order. Rule with order 0 is a special rule. It does not require any condition and actions listed in it will always be applied. </summary>
        public int? Order { get; set; }
        /// <summary> A list of conditions that must be matched for the actions to be executed. </summary>
        public IList<DeliveryRuleCondition> Conditions { get; }
        /// <summary> A list of actions that are executed when all the conditions of a rule are satisfied. </summary>
        public IList<DeliveryRuleAction> Actions { get; }
        /// <summary> If this rule is a match should the rules engine continue running the remaining rules or stop. If not present, defaults to Continue. </summary>
        public MatchProcessingBehavior? MatchProcessingBehavior { get; set; }
    }
}
