[![Terraform Infrastructure Deployment](https://github.com/crgarcia12/azure-contosobank-application-one/actions/workflows/infra.yml/badge.svg)](https://github.com/crgarcia12/azure-contosobank-application-one/actions/workflows/infra.yml)
[![Build and deploy an app to AKS](https://github.com/crgarcia12/azure-contosobank-application-one/actions/workflows/app.yml/badge.svg)](https://github.com/crgarcia12/azure-contosobank-application-one/actions/workflows/app.yml)
# azure-aks-advanced
This project tries out different AKS features:

# Set GitHub secrets
Standing on the git directory:

```
$subscriptionid = "14506188-80f8-4dc6-9b28-250051fc4ee4"
az ad sp create-for-rbac --name "crgar-contosobank-application-one" --role owner --scopes /subscriptions/$subscriptionid --sdk-auth

gh secret set AZURE_CLIENT_ID     --repos crgarcia12/azure-contosobank-application-one --body "<secret>"
gh secret set AZURE_CLIENT_SECRET --repos crgarcia12/azure-contosobank-application-one --body "<secret>"
gh secret set AZURE_TENANT_ID     --repos crgarcia12/azure-contosobank-application-one --body "<secret>"
gh secret set AZURE_SUBSCRIPTION    --repos crgarcia12/azure-contosobank-application-one --body "<secret>"

$AZURECRED = @"
{
  "clientId": "f48a1772-1f22-480f-976e-534dfed0a005",
  "clientSecret": "euB8Q~vQPEuehBTzIKAX~ApbSRFehFY9Wa8Z8aQK",
  "subscriptionId": "14506188-80f8-4dc6-9b28-250051fc4ee4",
  "tenantId": "b317d745-eb97-4068-9a14-a2e967b0b72e",
  "activeDirectoryEndpointUrl": "https://login.microsoftonline.com",
  "resourceManagerEndpointUrl": "https://management.azure.com/",
  "activeDirectoryGraphResourceId": "https://graph.windows.net/",
  "sqlManagementEndpointUrl": "https://management.core.windows.net:8443/",
  "galleryEndpointUrl": "https://gallery.azure.com/",
  "managementEndpointUrl": "https://management.core.windows.net/"
}
"@

gh secret set AZURE_CREDENTIALS  --repos crgarcia12/azure-contosobank-application-one --body "$AZURECRED"

```