      $["x-ms-client-name"] = "PatchMode"
# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
arm-core: true
clear-output-folder: true
skip-csproj: true
model-namespace: false
public-clients: false
head-as-boolean: false
mgmt-debug:
  show-request-path: true
batch:
  - tag: package-common-type
  - tag: package-resources
  - tag: package-management
```

### Tag: package-common-type

These settings apply only when `--tag=package-common-type` is specified on the command line.

``` yaml $(tag) == 'package-common-type'
output-folder: $(this-folder)/Common/Generated
namespace: Azure.ResourceManager
input-file:
  - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/be8b6e1fc69e7c2700847d6a9c344c0e204294ce/specification/common-types/resource-management/v3/types.json
  - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/be8b6e1fc69e7c2700847d6a9c344c0e204294ce/specification/common-types/resource-management/v4/managedidentity.json

rename-rules:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  Vmos: VmOS
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4
  Ipv6: IPv6
  Ipsec: IPsec
  SSO: Sso
  URI: Uri

directive:
  - remove-model: "AzureEntityResource"
  - remove-model: "ProxyResource"
  - remove-model: "ResourceModelWithAllowedPropertySet"
  - remove-model: "Identity"
  - remove-model: "Operation"
  - remove-model: "OperationListResult"
  - remove-model: "OperationStatusResult"
  - remove-model: "locationData"
  - remove-model: "CheckNameAvailabilityRequest"
  - remove-model: "CheckNameAvailabilityResponse"
  - remove-model: "ErrorResponse"
  - remove-model: "ErrorDetail"
  - remove-model: "ErrorAdditionalInfo"
  - from: types.json
    where: $.definitions['Resource']
    transform: >
      $["x-ms-mgmt-referenceType"] = true
  - from: types.json
    where: $.definitions['TrackedResource']
    transform: >
      $["x-ms-mgmt-referenceType"] = true
  - from: types.json
    where: $.definitions.*
    transform: >
      $["x-ms-mgmt-propertyReferenceType"] = true;
      $["x-namespace"] = "Azure.ResourceManager.Models";
      $["x-accessibility"] = "public";
      $["x-csharp-formats"] = "json";
      $["x-csharp-usage"] = "model,input,output";
  - from: types.json
    where: $.definitions.*.properties[?(@.enum)]
    transform: >
      $["x-namespace"] = "Azure.ResourceManager.Models";
      $["x-accessibility"] = "public";
# Workaround for the issue that SystemData lost readonly attribute: https://github.com/Azure/autorest/issues/4269
  - from: types.json
    where: $.definitions.systemData.properties.*
    transform: >
      $["readOnly"] = true
  - from: managedidentity.json
    where: $.definitions.*
    transform: >
      $["x-ms-mgmt-propertyReferenceType"] = true;
      $["x-namespace"] = "Azure.ResourceManager.Models";
      $["x-accessibility"] = "public";
      $["x-csharp-formats"] = "json";
      $["x-csharp-usage"] = "model,input,output";
  - from: managedidentity.json
    where: $.definitions.SystemAssignedServiceIdentity.properties.type
    transform: $["x-ms-client-name"] = "SystemAssignedServiceIdentityType"
```

### Tag: package-resources

These settings apply only when `--tag=package-resources` is specified on the command line.

``` yaml $(tag) == 'package-resources'
output-folder: $(this-folder)/Resources/Generated
namespace: Azure.ResourceManager.Resources
title: ResourceManagementClient
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-09-01/policyAssignments.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Resources/stable/2021-04-01/resources.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-09-01/policyDefinitions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-09-01/policySetDefinitions.json
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/preview/2020-07-01-preview/policyExemptions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-09-01/dataPolicyManifests.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/stable/2016-09-01/locks.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Resources/stable/2016-09-01/links.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Resources/stable/2021-01-01/subscriptions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Features/stable/2021-07-01/features.json
list-exception:
  - /{linkId}
  - /{resourceId}
request-path-to-resource-data:
  # subscription does not have name and type
  /subscriptions/{subscriptionId}: Subscription
  # tenant does not have name and type
  /: Tenant
  # provider does not have name and type
  /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}: ResourceProvider
request-path-is-non-resource:
  - /subscriptions/{subscriptionId}/locations
request-path-to-parent:
  /{scope}/providers/Microsoft.Resources/links: /{linkId}
  /subscriptions: /subscriptions/{subscriptionId}
  /tenants: /
  /subscriptions/{subscriptionId}/locations: /subscriptions/{subscriptionId}
  /subscriptions/{subscriptionId}/providers: /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}
  /subscriptions/{subscriptionId}/providers/Microsoft.Features/providers/{resourceProviderNamespace}/features/{featureName}: /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}
request-path-to-resource-type:
  /{linkId}: Microsoft.Resources/links
  /subscriptions/{subscriptionId}/locations: Microsoft.Resources/locations
  /tenants: Microsoft.Resources/tenants
  /: Microsoft.Resources/tenants
  /subscriptions: Microsoft.Resources/subscriptions
  /subscriptions/{subscriptionId}/resourcegroups: Microsoft.Resources/resourceGroups
  /subscriptions/{subscriptionId}/providers/Microsoft.Features/providers/{resourceProviderNamespace}/features/{featureName}: Microsoft.Resources/features
  /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}: Microsoft.Resources/providers
  /providers: Microsoft.Resources/providers
request-path-to-scope-resource-types:
  /{scope}/providers/Microsoft.Authorization/locks/{lockName}:
    - subscriptions
    - resourceGroups
    - "*"
operation-groups-to-omit:
  - Deployments
  - DeploymentOperations
  - AuthorizationOperations
  - ResourceCheck
override-operation-name:
  ResourceLinks_ListAtSourceScope: GetAll
  Tags_List: GetAllPredefinedTags
  Tags_DeleteValue: DeletePredefinedTagValue
  Tags_CreateOrUpdateValue: CreateOrUpdatePredefinedTagValue
  Tags_CreateOrUpdate: CreateOrUpdatePredefinedTag
  Tags_Delete: DeletePredefinedTag
  Providers_ListAtTenantScope: GetTenantResourceProviders
  Providers_GetAtTenantScope: GetTenantResourceProvider
  Resources_MoveResources: MoveResources
  Resources_ValidateMoveResources: ValidateMoveResources
  Resources_List: GetGenericResources
  Resources_ListByResourceGroup: GetGenericResources
  Providers_RegisterAtManagementGroupScope: RegisterResourceProvider
  ResourceLinks_ListAtSubscription: GetResourceLinks

no-property-type-replacement: ResourceProviderData;ResourceProvider;

rename-rules:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  Vmos: VmOS
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4
  Ipv6: IPv6
  Ipsec: IPsec
  SSO: Sso
  URI: Uri

directive:
  # These methods can be replaced by using other methods in the same operation group, remove for Preview.
  - remove-operation: PolicyAssignments_DeleteById
  - remove-operation: PolicyAssignments_CreateById
  - remove-operation: PolicyAssignments_GetById
  - remove-operation: ManagementLocks_CreateOrUpdateAtResourceGroupLevel
  - remove-operation: ManagementLocks_CreateOrUpdateAtResourceLevel
  - remove-operation: ManagementLocks_CreateOrUpdateAtSubscriptionLevel
  - remove-operation: ManagementLocks_DeleteAtResourceGroupLevel
  - remove-operation: ManagementLocks_DeleteAtResourceLevel
  - remove-operation: ManagementLocks_DeleteAtSubscriptionLevel
  - remove-operation: ManagementLocks_GetAtResourceGroupLevel
  - remove-operation: ManagementLocks_GetAtResourceLevel
  - remove-operation: ManagementLocks_GetAtSubscriptionLevel
  - remove-operation: ManagementLocks_ListAtResourceGroupLevel
  - remove-operation: ManagementLocks_ListAtResourceLevel
  - remove-operation: ManagementLocks_ListAtSubscriptionLevel
  # These methods was not in the previous manual code, remove them for the first generation and can add them back later.
  - remove-operation: ResourceGroups_CheckExistence
  - remove-operation: Resources_CheckExistenceById
  - remove-operation: Resources_CheckExistence
  - remove-operation: Resources_CreateOrUpdate
  - remove-operation: Resources_Update
  - remove-operation: Resources_Get
  - remove-operation: Resources_Delete
  - remove-operation: Providers_RegisterAtManagementGroupScope
  # Deduplicate
  - from: subscriptions.json
    where: '$.paths["/providers/Microsoft.Resources/operations"].get'
    transform: >
      $["operationId"] = "Operations_ListSubscriptionOperations";
    reason: Rename duplicate operation Id.
  - from: resources.json
    where: '$.paths["/providers/Microsoft.Resources/operations"].get'
    transform: >
      $["operationId"] = "Operations_ListResourcesOperations";
    reason: Rename duplicate operation Id.
  - from: features.json
    where: '$.paths["/providers/Microsoft.Features/operations"].get'
    transform: >
      $["operationId"] = "Operations_ListFeaturesOperations";
    reason: Add operation group so that we can omit related models by the operation group.
  - from: locks.json
    where: $.definitions
    transform: >
      $["OperationListResult"]["x-ms-client-name"] = "ManagementLockOperationListResult";
      $["Operation"]["x-ms-client-name"] = "ManagementLockOperation";
      $["Operation"]["properties"]["displayOfManagementLock"] = $["Operation"]["properties"]["display"];
      $["Operation"]["properties"]["display"] = undefined;
  - from: links.json
    where: $.definitions
    transform: >
      $["OperationListResult"]["x-ms-client-name"] = "ResourceLinkOperationListResult";
      $["Operation"]["x-ms-client-name"] = "ResourceLinksOperation";
  - from: subscriptions.json
    where: $.definitions
    transform: >
      $["OperationListResult"]["x-ms-client-name"] = "SubscriptionOperationListResult";
      $["Operation"]["x-ms-client-name"] = "SubscriptionOperation";
  - from: features.json
    where: $.definitions
    transform: >
      $["OperationListResult"]["x-ms-client-name"] = "FeatureOperationListResult";
      $["Operation"]["x-ms-client-name"] = "FeatureOperation";
      $["Operation"]["properties"]["displayOfFeature"] = $["Operation"]["properties"]["display"];
      $["Operation"]["properties"]["display"] = undefined;
  - from: features.json
    where: $.definitions.ErrorResponse
    transform: >
      $["x-ms-client-name"] = "FeatureErrorResponse";

  - rename-operation:
      from: checkResourceName
      to: ResourceCheck_CheckResourceName
  - rename-operation:
      from: Resources_MoveResources
      to: ResourceGroups_MoveResources
  - rename-operation:
      from: Resources_ValidateMoveResources
      to: ResourceGroups_ValidateMoveResources

# TODO - remove when Azure.ErrorResponse is marked as PropertyReferenceType
  - from: types.json
    where: $.definitions.ErrorResponse
    transform: $["x-ms-client-name"] = "ResponseError"

  - rename-model:
      from: Location
      to: LocationExpanded
  - rename-model:
      from: Provider
      to: ResourceProvider
  - rename-model:
      from: ProviderListResult
      to: ResourceProviderListResult
  - rename-model:
      from: TenantIdDescription
      to: Tenant
  - rename-model:
      from: Tags
      to: Tag
  - rename-model:
      from: TagsResource
      to: TagResource
  - rename-model:
      from: TagsPatchResource
      to: TagPatchResource
  - rename-model:
      from: TagCount
      to: PredefinedTagCount
  - rename-model:
      from: TagValue
      to: PredefinedTagValue
  - rename-model:
      from: TagDetails
      to: PredefinedTag
  - rename-model:
      from: TagsListResult
      to: PredefinedTagsListResult
  - rename-model:
      from: FeatureResult
      to: Feature
  - rename-model:
      from: Resource
      to: TrackedResourceExtendedData
  - rename-model:
      from: ProviderRegistrationRequest
      to: ResourceProviderRegistrationOptions
  - from: resources.json
    where: $.definitions.Provider
    transform:
      $["x-ms-client-name"] = "ResourceProvider";
  - from: resources.json
    where: $.definitions.Alias
    transform:
      $["x-ms-client-name"] = "ResourceTypeAlias";
  - from: resources.json
    where: $.definitions.AliasPath
    transform:
      $["x-ms-client-name"] = "ResourceTypeAliasPath";
  - from: resources.json
    where: $.definitions.AliasPathMetadata.properties.attributes["x-ms-enum"]
    transform:
      $["name"] = "ResourceTypeAliasPathAttributes";
  - from: resources.json
    where: $.definitions.AliasPathMetadata
    transform:
      $["x-ms-client-name"] = "ResourceTypeAliasPathMetadata";
  - from: resources.json
    where: $.definitions.AliasPathMetadata.properties.type["x-ms-enum"]
    transform:
      $["name"] = "ResourceTypeAliasPathTokenType";
  - from: resources.json
    where: $.definitions.AliasPattern
    transform:
      $["x-ms-client-name"] = "ResourceTypeAliasPattern";
  - from: resources.json
    where: $.definitions.AliasPattern.properties.type["x-ms-enum"]
    transform:
      $["name"] = "ResourceTypeAliasPatternType";
  - from: resources.json
    where: $.definitions.Alias.properties.type["x-ms-enum"]
    transform:
      $["name"] = "ResourceTypeAliasType";
  - from: policyDefinitions.json
    where: $.definitions.ParameterDefinitionsValue
    transform:
      $["x-ms-client-name"] = "ArmPolicyParameter";
  - from: policyDefinitions.json
    where: $.definitions.ParameterDefinitionsValue.properties.type["x-ms-enum"]
    transform:
      $["name"] = "ArmPolicyParameterType";
  - from: policyAssignments.json
    where: $.definitions.ParameterValuesValue
    transform:
      $["x-ms-client-name"] = "ArmPolicyParameterValue";
  - remove-model: DeploymentExtendedFilter
  - remove-model: ResourceProviderOperationDisplayProperties
  - from: subscriptions.json
    where: $.paths
    transform: >
      $["/"] = {
        "get": {
          "tags": [
            "Tenants"
          ],
          "operationId": "Tenants_Get",
          "description": "Gets details about the default tenant.",
          "parameters": [
            {
              "$ref": "#/parameters/ApiVersionParameter"
            }
          ],
          "responses": {
            "200": {
              "description": "OK - Returns information about the tenant.",
              "schema": {
                "$ref": "#/definitions/Tenant"
              }
            },
            "default": {
              "description": "Error response describing why the operation failed.",
              "schema": {
                "$ref": "#/definitions/CloudError"
              }
            }
          }
        }
      }
    reason: add a fake tenant get operation so that we can generate a tenant where all the Get[TenantResources] operations can be autogen in it. The get operation will be removed with codegen suppress attributes.

  - from: resources.json
    where: $.definitions
    transform: >
      $["TenantResourceProvider"] = {
        "properties": {
          "namespace": {
            "type": "string",
            "description": "The namespace of the resource provider."
          },
          "resourceTypes": {
            "readOnly": true,
            "type": "array",
            "items": {
              "$ref": "#/definitions/ProviderResourceType"
            },
            "description": "The collection of provider resource types."
          }
        },
        "description": "Resource provider information."
      }
    reason: This is the real response for a tenant provider.
  - from: resources.json
    where: $.definitions
    transform: >
      $["TenantResourceProviderListResult"] = {
        "properties": {
          "value": {
            "type": "array",
            "items": {
              "$ref": "#/definitions/TenantResourceProvider"
            },
            "description": "An array of resource providers."
          },
          "nextLink": {
            "readOnly": true,
            "type": "string",
            "description": "The URL to use for getting the next set of results."
          }
        },
        "description": "List of resource providers."
      }
  - from: resources.json
    where: $.definitions.TenantResourceProviderListResult.properties.value.items["$ref"]
    transform: return "#/definitions/TenantResourceProvider"
  - from: resources.json
    where: $.paths["/providers"].get.responses["200"].schema["$ref"]
    transform: return "#/definitions/TenantResourceProviderListResult"
  - from: resources.json
    where: $.paths["/providers/{resourceProviderNamespace}"].get.responses["200"].schema["$ref"]
    transform: return "#/definitions/TenantResourceProvider"

  - from: resources.json
    where: $.definitions.Identity.properties.type["x-ms-enum"]
    transform: > 
      $["name"] = "GenericResourceIdentityType";
      $["modelAsString"] = true;
  - from: resources.json
    where: $.definitions.Identity
    transform: > 
      $["required"] = ["type"]
  - from: resources.json
    where: $.definitions.Identity
    transform: >
      $["x-ms-client-name"] = "GenericResourceIdentity";
  - from: policyAssignments.json
    where: $.definitions.Identity.properties.type["x-ms-enum"]
    transform: $["name"] = "PolicyAssignmentIdentityType"
  - from: policyAssignments.json
    where: $.definitions.Identity
    transform: >
      $["x-ms-client-name"] = "PolicyAssignmentIdentity";
  - from: locks.json
    where: $.paths..parameters[?(@.name === "scope")]
    transform: >
      $["x-ms-skip-url-encoding"] = true
  # Rename GenericResourceExpanded to GenericResource and use it as the schema for both single resource operation and collection operation.
  - from: resources.json
    where: $.definitions.ResourceListResult.properties.value.items["$ref"]
    transform: >
      $ = "#/definitions/GenericResource"
  - from: resources.json
    where: $.definitions
    transform: >
      $.GenericResource.properties["createdTime"] = $.GenericResourceExpanded.properties["createdTime"];
      $.GenericResource.properties["changedTime"] = $.GenericResourceExpanded.properties["changedTime"];
      $.GenericResource.properties["provisioningState"] = $.GenericResourceExpanded.properties["provisioningState"];
      delete $.GenericResourceExpanded;
#   - from: resources.json
#     where: $.definitions['Provider']
#     transform: >
#       $["x-ms-mgmt-propertyReferenceType"] = true # not supported with ResourceData yet, use custom code first
  - from: locks.json
    where: $.definitions.ManagementLockObject
    transform: $["x-ms-client-name"] = "ManagementLock"
  - from: links.json
    where: $.definitions.ResourceLink.properties.type
    transform: >
      $["x-ms-client-name"] = "ResourceType";
      $["type"] = "string";
  - from: dataPolicyManifests.json
    where: $.definitions.DataEffect
    transform: >
      $["x-ms-client-name"] = "DataPolicyManifestEffect";
  - from: locks.json
    where: $.definitions.ManagementLockProperties.properties.level["x-ms-enum"]
    transform: >
      $["name"] = "ManagementLockLevel"
  - from: subscriptions.json
    where: $.definitions.Subscription.properties.tenantId
    transform: >
      $['format'] = "uuid"
  - from: subscriptions.json
    where: $.definitions.Tenant.properties.tenantId
    transform: >
      $['format'] = "uuid"
  - from: subscriptions.json
    where: $.definitions.ManagedByTenant.properties.tenantId
    transform: >
      $['format'] = "uuid"
  - from: resources.json
    where: $.definitions.ResourcesMoveInfo.properties.resources.items
    transform: >
      $["x-ms-format"] = "arm-id"
  - from: resources.json
    where: $.definitions.RoleDefinition
    transform: >
      $["x-ms-client-name"] = "AzureRoleDefinition";
  - from: resources.json
    where: $.definitions.TagPatchResource.properties.operation["x-ms-enum"]
    transform: >
      $["name"] = "TagPatchMode"
  - from: resources.json
    where: $.definitions.TagPatchResource.properties.operation
    transform: >
      $["x-ms-client-name"] = "PatchMode"
  - from: dataPolicyManifests.json
    where: $.definitions.DataManifestResourceFunctionsDefinition.properties.custom
    transform: >
      $["x-ms-client-name"] = "CustomDefinitions"
  - from: policyAssignments.json
    where: $.definitions.PolicyAssignmentProperties.properties.notScopes
    transform: >
      $["x-ms-client-name"] = "ExcludedScopes"
  - from: resources.json
    where: $.definitions.ExportTemplateRequest
    transform: >
      $["x-ms-client-name"] = "ExportTemplate"
  - from: policyAssignments.json
    where: $.definitions.PolicyAssignmentProperties.properties.enforcementMode["x-ms-enum"].values[0]
    transform: >
      $["value"] = "Enforced"
  - from: dataPolicyManifests.json
    where: $.definitions.DataManifestCustomResourceFunctionDefinition.properties.fullyQualifiedResourceType
    transform: >
      $["x-ms-format"] = "resource-type"
  - from: resources.json
    where: $.definitions.Permission.properties.actions
    transform: >
      $["x-ms-client-name"] = "AllowedActions"
  - from: resources.json
    where: $.definitions.Permission.properties.notActions
    transform: >
      $["x-ms-client-name"] = "DeniedActions"
  - from: resources.json
    where: $.definitions.Permission.properties.dataActions
    transform: >
      $["x-ms-client-name"] = "AllowedDataActions"
  - from: resources.json
    where: $.definitions.Permission.properties.notDataActions
    transform: >
      $["x-ms-client-name"] = "DeniedDataActions"
  - from: policyAssignments.json
    where: $.definitions.PolicyAssignment.properties.location
    transform: >
      $["x-ms-format"] = "azure-location"
  - from: resources.json
    where: $.definitions.ProviderExtendedLocation.properties.location
    transform: >
      $["x-ms-format"] = "azure-location"
```

### Tag: package-management

These settings apply only when `--tag=package-management` is specified on the command line.

``` yaml $(tag) == 'package-management'
output-folder: $(this-folder)/ManagementGroup/Generated
namespace: Azure.ResourceManager.ManagementGroups
title: ManagementClient
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/94a37114e8f4067410b52d3b1c75aa6e09180658/specification/managementgroups/resource-manager/Microsoft.Management/stable/2021-04-01/management.json
request-path-to-parent:
  /providers/Microsoft.Management/managementGroups: /providers/Microsoft.Management/managementGroups/{groupId}
  /providers/Microsoft.Management/checkNameAvailability: /providers/Microsoft.Management/managementGroups/{groupId}
operation-positions:
  /providers/Microsoft.Management/checkNameAvailability: collection
operation-groups-to-omit:
  - HierarchySettings
  - ManagementGroupSubscriptions
  - Entities
  - TenantBackfill
no-property-type-replacement: DescendantParentGroupInfo

rename-rules:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  Vmos: VmOS
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4
  Ipv6: IPv6
  Ipsec: IPsec
  SSO: Sso
  URI: Uri
override-operation-name:
  ManagementGroups_CheckNameAvailability: CheckManagementGroupNameAvailability
directive:
  - rename-model:
      from: PatchManagementGroupRequest
      to: PatchManagementGroupOptions
  - rename-model:
      from: CreateManagementGroupRequest
      to: CreateManagementGroupOptions
  - rename-model:
      from: CreateManagementGroupChildInfo
      to: ManagementGroupChildOptions
  - rename-model:
      from: CreateParentGroupInfo
      to: ManagementGroupParentCreateOptions
  - from: management.json
    where: $.definitions.CheckNameAvailabilityRequest.properties.type
    transform: >
      $['x-ms-client-name'] = "ResourceType"
  - rename-model:
      from: CheckNameAvailabilityRequest
      to: ManagementGroupNameAvailabilityOptions
  - rename-operation:
      from: CheckNameAvailability
      to: ManagementGroups_CheckNameAvailability
  - rename-operation:
      from: StartTenantBackfill
      to: TenantBackfill_Start
  - rename-operation:
      from: TenantBackfillStatus
      to: TenantBackfill_Status
  - from: management.json
    where: $.parameters.CheckNameAvailabilityParameter
    transform: >
      $['name'] = "checkNameAvailabilityOptions"
  - from: management.json
    where: $.parameters.ExpandParameter
    transform: >
      $['x-ms-enum'] = {
        name: "ManagementGroupExpandType",
        modelAsString: true
      }
  - from: management.json
    where: $.definitions.ManagementGroupListResult.properties.value.items
    transform: >
      $['$ref'] = "#/definitions/ManagementGroup"
  - from: management.json
    where: $.definitions.ManagementGroupInfo
    transform: 'return undefined'
  - remove-model: OperationResults
  - from: management.json
    where: $.definitions.CheckNameAvailabilityResult.properties.reason
    transform: >
      $['x-ms-enum'] = {
        name: "ManagementGroupNameUnavailableReason"
      }
  - from: management.json
    where: $.definitions.CheckNameAvailabilityResult
    transform: >
      $['x-ms-client-name'] = "ManagementGroupNameAvailabilityResult"
  - from: management.json
    where: $.parameters.SearchParameter
    transform: >
      $['x-ms-enum'] = {
        name: "SearchOptions",
        modelAsString: true
      }
    reason: omit operation group does not clean this enum parameter, rename it and then suppress with codegen attribute.
  - from: management.json
    where: $.parameters.EntityViewParameter
    transform: >
      $['x-ms-enum'] = {
        name: "EntityViewOptions",
        modelAsString: true
      }
    reason: omit operation group does not clean this enum parameter, rename it and then suppress with codegen attribute.
  - remove-model: EntityHierarchyItem
  - remove-model: EntityHierarchyItemProperties
  - from: management.json
    where: $.definitions.CreateManagementGroupProperties.properties.tenantId
    transform: >
      $['format'] = "uuid"
  - from: management.json
    where: $.definitions.DescendantInfo
    transform: >
      $['x-ms-client-name'] = "DescendantData"
  - from: management.json
    where: $.definitions.DescendantParentGroupInfo.properties.id
    transform: >
      $["x-ms-format"] = "arm-id"
  - from: management.json
    where: $.definitions.ManagementGroupDetails.properties.managementGroupAncestorsChain
    transform: >
      $["x-ms-client-name"] = "managementGroupAncestorChain"
  - from: management.json
    where: $.definitions.ManagementGroupDetails
    transform: >
      $["x-ms-client-name"] = "ManagementGroupInfo"
  - from: management.json
    where: $.definitions.ParentGroupInfo
    transform: >
      $["x-ms-client-name"] = "ParentManagementGroupInfo"
  - from: management.json
    where: $.definitions.ManagementGroupProperties.properties.tenantId
    transform: >
      $['format'] = "uuid"
```
