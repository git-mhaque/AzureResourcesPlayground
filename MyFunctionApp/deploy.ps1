$rootPath = "C:/Code/gh/AzureCloudServicesPlayground/MyFunctionApp"
$functionAppName = "MH-FunctionApp"
$resourceGroup = "mh-default"
$storageAccountName = "mhdefaultstorage"
$location = "AustraliaSoutheast"

Set-Location $rootPath 

#=============================
# Build and publish the app  
#============================= 
dotnet build -c release
dotnet publish -c release 


#=============================
# Create the function app 
#============================= 
# az functionapp create -n $functionAppName --storage-account $storageAccountName --consumption-plan-location $location --runtime dotnet -g $resourceGroup


#=============================
# Create the zipped package 
#============================= 
$publishFolder = $rootPath + "/bin/Release/netcoreapp2.1/publish"
$publishZip = $rootPath + "/bin/Release/netcoreapp2.1/publish.zip"
if(Test-path $publishZip) { Remove-item $publishZip }
Add-Type -assembly "system.io.compression.filesystem"
[io.compression.zipfile]::CreateFromDirectory($publishFolder, $publishZip)

#=============================
# Deploy the zipped package 
#============================= 
az functionapp deployment source config-zip -g $resourceGroup -n $functionAppName --src $publishZip


#=============================
# Include app settings 
#============================= 
az functionapp config appsettings set -n $functionAppName -g $resourceGroup --settings "ServiceBusConnectionString=Endpoint=sb://mh-messaging.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=zq2dnRSYcFZEG2ldDJRlhKAABXFWElTCon31dre5MmI="