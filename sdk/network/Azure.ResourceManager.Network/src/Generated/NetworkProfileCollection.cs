// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A class representing a collection of <see cref="NetworkProfileResource" /> and their operations.
    /// Each <see cref="NetworkProfileResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="NetworkProfileCollection" /> instance call the GetNetworkProfiles method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class NetworkProfileCollection : ArmCollection, IEnumerable<NetworkProfileResource>, IAsyncEnumerable<NetworkProfileResource>
    {
        private readonly ClientDiagnostics _networkProfileClientDiagnostics;
        private readonly NetworkProfilesRestOperations _networkProfileRestClient;

        /// <summary> Initializes a new instance of the <see cref="NetworkProfileCollection"/> class for mocking. </summary>
        protected NetworkProfileCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="NetworkProfileCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal NetworkProfileCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _networkProfileClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", NetworkProfileResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(NetworkProfileResource.ResourceType, out string networkProfileApiVersion);
            _networkProfileRestClient = new NetworkProfilesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, networkProfileApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a network profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkProfiles/{networkProfileName}
        /// Operation Id: NetworkProfiles_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="networkProfileName"> The name of the network profile. </param>
        /// <param name="data"> Parameters supplied to the create or update network profile operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="networkProfileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkProfileName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<NetworkProfileResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string networkProfileName, NetworkProfileData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkProfileName, nameof(networkProfileName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _networkProfileClientDiagnostics.CreateScope("NetworkProfileCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _networkProfileRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, networkProfileName, data, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<NetworkProfileResource>(Response.FromValue(new NetworkProfileResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or updates a network profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkProfiles/{networkProfileName}
        /// Operation Id: NetworkProfiles_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="networkProfileName"> The name of the network profile. </param>
        /// <param name="data"> Parameters supplied to the create or update network profile operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="networkProfileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkProfileName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<NetworkProfileResource> CreateOrUpdate(WaitUntil waitUntil, string networkProfileName, NetworkProfileData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkProfileName, nameof(networkProfileName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _networkProfileClientDiagnostics.CreateScope("NetworkProfileCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _networkProfileRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, networkProfileName, data, cancellationToken);
                var operation = new NetworkArmOperation<NetworkProfileResource>(Response.FromValue(new NetworkProfileResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified network profile in a specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkProfiles/{networkProfileName}
        /// Operation Id: NetworkProfiles_Get
        /// </summary>
        /// <param name="networkProfileName"> The name of the public IP prefix. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="networkProfileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkProfileName"/> is null. </exception>
        public virtual async Task<Response<NetworkProfileResource>> GetAsync(string networkProfileName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkProfileName, nameof(networkProfileName));

            using var scope = _networkProfileClientDiagnostics.CreateScope("NetworkProfileCollection.Get");
            scope.Start();
            try
            {
                var response = await _networkProfileRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, networkProfileName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NetworkProfileResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified network profile in a specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkProfiles/{networkProfileName}
        /// Operation Id: NetworkProfiles_Get
        /// </summary>
        /// <param name="networkProfileName"> The name of the public IP prefix. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="networkProfileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkProfileName"/> is null. </exception>
        public virtual Response<NetworkProfileResource> Get(string networkProfileName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkProfileName, nameof(networkProfileName));

            using var scope = _networkProfileClientDiagnostics.CreateScope("NetworkProfileCollection.Get");
            scope.Start();
            try
            {
                var response = _networkProfileRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, networkProfileName, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NetworkProfileResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all network profiles in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkProfiles
        /// Operation Id: NetworkProfiles_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NetworkProfileResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NetworkProfileResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<NetworkProfileResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _networkProfileClientDiagnostics.CreateScope("NetworkProfileCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _networkProfileRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new NetworkProfileResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<NetworkProfileResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _networkProfileClientDiagnostics.CreateScope("NetworkProfileCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _networkProfileRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new NetworkProfileResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets all network profiles in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkProfiles
        /// Operation Id: NetworkProfiles_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NetworkProfileResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NetworkProfileResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<NetworkProfileResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _networkProfileClientDiagnostics.CreateScope("NetworkProfileCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _networkProfileRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new NetworkProfileResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<NetworkProfileResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _networkProfileClientDiagnostics.CreateScope("NetworkProfileCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _networkProfileRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new NetworkProfileResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkProfiles/{networkProfileName}
        /// Operation Id: NetworkProfiles_Get
        /// </summary>
        /// <param name="networkProfileName"> The name of the public IP prefix. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="networkProfileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkProfileName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string networkProfileName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkProfileName, nameof(networkProfileName));

            using var scope = _networkProfileClientDiagnostics.CreateScope("NetworkProfileCollection.Exists");
            scope.Start();
            try
            {
                var response = await _networkProfileRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, networkProfileName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkProfiles/{networkProfileName}
        /// Operation Id: NetworkProfiles_Get
        /// </summary>
        /// <param name="networkProfileName"> The name of the public IP prefix. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="networkProfileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkProfileName"/> is null. </exception>
        public virtual Response<bool> Exists(string networkProfileName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkProfileName, nameof(networkProfileName));

            using var scope = _networkProfileClientDiagnostics.CreateScope("NetworkProfileCollection.Exists");
            scope.Start();
            try
            {
                var response = _networkProfileRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, networkProfileName, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<NetworkProfileResource> IEnumerable<NetworkProfileResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<NetworkProfileResource> IAsyncEnumerable<NetworkProfileResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
