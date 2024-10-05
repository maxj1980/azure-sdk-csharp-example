
using Azure;
using Azure.Identity;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

// First, initialize the ArmClient and get the default subscription
var client = new ArmClient(new DefaultAzureCredential());

// Now we get a ResourceGroupResource collection for that subscription
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();

// With the collection, we can create a new resource group with an specific name
string resourceGroupName = "myRgName";
AzureLocation location = AzureLocation.UKSouth;
ResourceGroupData resourceGroupData = new ResourceGroupData(location);
ArmOperation<ResourceGroupResource> operation = await resourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, resourceGroupData);
ResourceGroupResource resourceGroup = operation.Value;