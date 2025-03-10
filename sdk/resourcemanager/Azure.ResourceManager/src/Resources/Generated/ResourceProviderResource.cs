// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A Class representing a ResourceProvider along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="ResourceProviderResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetResourceProviderResource method.
    /// Otherwise you can get one from its parent resource <see cref="SubscriptionResource" /> using the GetResourceProvider method.
    /// </summary>
    public partial class ResourceProviderResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="ResourceProviderResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceProviderNamespace)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _resourceProviderProvidersClientDiagnostics;
        private readonly ProvidersRestOperations _resourceProviderProvidersRestClient;
        private readonly ClientDiagnostics _providerResourceTypesClientDiagnostics;
        private readonly ProviderResourceTypesRestOperations _providerResourceTypesRestClient;
        private readonly ResourceProviderData _data;

        /// <summary> Initializes a new instance of the <see cref="ResourceProviderResource"/> class for mocking. </summary>
        protected ResourceProviderResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "ResourceProviderResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal ResourceProviderResource(ArmClient client, ResourceProviderData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="ResourceProviderResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ResourceProviderResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _resourceProviderProvidersClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string resourceProviderProvidersApiVersion);
            _resourceProviderProvidersRestClient = new ProvidersRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, resourceProviderProvidersApiVersion);
            _providerResourceTypesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _providerResourceTypesRestClient = new ProviderResourceTypesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Resources/providers";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ResourceProviderData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary> Gets a collection of FeatureResources in the ResourceProvider. </summary>
        /// <returns> An object representing collection of FeatureResources and their operations over a FeatureResource. </returns>
        public virtual FeatureCollection GetFeatures()
        {
            return GetCachedClient(Client => new FeatureCollection(Client, Id));
        }

        /// <summary>
        /// Gets the preview feature with the specified name.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Features/providers/{resourceProviderNamespace}/features/{featureName}
        /// Operation Id: Features_Get
        /// </summary>
        /// <param name="featureName"> The name of the feature to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="featureName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="featureName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<FeatureResource>> GetFeatureAsync(string featureName, CancellationToken cancellationToken = default)
        {
            return await GetFeatures().GetAsync(featureName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the preview feature with the specified name.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Features/providers/{resourceProviderNamespace}/features/{featureName}
        /// Operation Id: Features_Get
        /// </summary>
        /// <param name="featureName"> The name of the feature to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="featureName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="featureName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<FeatureResource> GetFeature(string featureName, CancellationToken cancellationToken = default)
        {
            return GetFeatures().Get(featureName, cancellationToken);
        }

        /// <summary>
        /// Gets the specified resource provider.
        /// Request Path: /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}
        /// Operation Id: Providers_Get
        /// </summary>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ResourceProviderResource>> GetAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _resourceProviderProvidersClientDiagnostics.CreateScope("ResourceProviderResource.Get");
            scope.Start();
            try
            {
                var response = await _resourceProviderProvidersRestClient.GetAsync(Id.SubscriptionId, Id.Provider, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResourceProviderResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified resource provider.
        /// Request Path: /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}
        /// Operation Id: Providers_Get
        /// </summary>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ResourceProviderResource> Get(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _resourceProviderProvidersClientDiagnostics.CreateScope("ResourceProviderResource.Get");
            scope.Start();
            try
            {
                var response = _resourceProviderProvidersRestClient.Get(Id.SubscriptionId, Id.Provider, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResourceProviderResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Unregisters a subscription from a resource provider.
        /// Request Path: /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}/unregister
        /// Operation Id: Providers_Unregister
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ResourceProviderResource>> UnregisterAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _resourceProviderProvidersClientDiagnostics.CreateScope("ResourceProviderResource.Unregister");
            scope.Start();
            try
            {
                var response = await _resourceProviderProvidersRestClient.UnregisterAsync(Id.SubscriptionId, Id.Provider, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ResourceProviderResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Unregisters a subscription from a resource provider.
        /// Request Path: /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}/unregister
        /// Operation Id: Providers_Unregister
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ResourceProviderResource> Unregister(CancellationToken cancellationToken = default)
        {
            using var scope = _resourceProviderProvidersClientDiagnostics.CreateScope("ResourceProviderResource.Unregister");
            scope.Start();
            try
            {
                var response = _resourceProviderProvidersRestClient.Unregister(Id.SubscriptionId, Id.Provider, cancellationToken);
                return Response.FromValue(new ResourceProviderResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the provider permissions.
        /// Request Path: /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}/providerPermissions
        /// Operation Id: Providers_ProviderPermissions
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ProviderPermission" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ProviderPermission> ProviderPermissionsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ProviderPermission>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _resourceProviderProvidersClientDiagnostics.CreateScope("ResourceProviderResource.ProviderPermissions");
                scope.Start();
                try
                {
                    var response = await _resourceProviderProvidersRestClient.ProviderPermissionsAsync(Id.SubscriptionId, Id.Provider, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Get the provider permissions.
        /// Request Path: /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}/providerPermissions
        /// Operation Id: Providers_ProviderPermissions
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ProviderPermission" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ProviderPermission> ProviderPermissions(CancellationToken cancellationToken = default)
        {
            Page<ProviderPermission> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _resourceProviderProvidersClientDiagnostics.CreateScope("ResourceProviderResource.ProviderPermissions");
                scope.Start();
                try
                {
                    var response = _resourceProviderProvidersRestClient.ProviderPermissions(Id.SubscriptionId, Id.Provider, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Registers a subscription with a resource provider.
        /// Request Path: /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}/register
        /// Operation Id: Providers_Register
        /// </summary>
        /// <param name="options"> The third party consent for S2S. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ResourceProviderResource>> RegisterAsync(ResourceProviderRegistrationOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _resourceProviderProvidersClientDiagnostics.CreateScope("ResourceProviderResource.Register");
            scope.Start();
            try
            {
                var response = await _resourceProviderProvidersRestClient.RegisterAsync(Id.SubscriptionId, Id.Provider, options, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ResourceProviderResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Registers a subscription with a resource provider.
        /// Request Path: /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}/register
        /// Operation Id: Providers_Register
        /// </summary>
        /// <param name="options"> The third party consent for S2S. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ResourceProviderResource> Register(ResourceProviderRegistrationOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _resourceProviderProvidersClientDiagnostics.CreateScope("ResourceProviderResource.Register");
            scope.Start();
            try
            {
                var response = _resourceProviderProvidersRestClient.Register(Id.SubscriptionId, Id.Provider, options, cancellationToken);
                return Response.FromValue(new ResourceProviderResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List the resource types for a specified resource provider.
        /// Request Path: /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}/resourceTypes
        /// Operation Id: ProviderResourceTypes_List
        /// </summary>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ProviderResourceType" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ProviderResourceType> GetProviderResourceTypesAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ProviderResourceType>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _providerResourceTypesClientDiagnostics.CreateScope("ResourceProviderResource.GetProviderResourceTypes");
                scope.Start();
                try
                {
                    var response = await _providerResourceTypesRestClient.ListAsync(Id.SubscriptionId, Id.Provider, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// List the resource types for a specified resource provider.
        /// Request Path: /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}/resourceTypes
        /// Operation Id: ProviderResourceTypes_List
        /// </summary>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ProviderResourceType" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ProviderResourceType> GetProviderResourceTypes(string expand = null, CancellationToken cancellationToken = default)
        {
            Page<ProviderResourceType> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _providerResourceTypesClientDiagnostics.CreateScope("ResourceProviderResource.GetProviderResourceTypes");
                scope.Start();
                try
                {
                    var response = _providerResourceTypesRestClient.List(Id.SubscriptionId, Id.Provider, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }
    }
}
