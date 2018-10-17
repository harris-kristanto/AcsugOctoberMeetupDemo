Param(
  [string]$unleashedApiKeySecretName,
  [string]$unleashedApiKeySecretValue,
  [string]$subscriptionId,
  [string]$servicePrincipalId,
  [string]$vaultName
)

#Retrieve Service Principal object of VSTS app registration in Azure AD.
$spn=(Get-AzureRmADServicePrincipal -SPN $servicePrincipalId)
$spnObjectId=$spn.Id

#Grant the Service Principal permissions to secrets in the Key Vault.
Set-AzureRmKeyVaultAccessPolicy -VaultName $vaultName -ObjectId $spnObjectId -PermissionsToSecrets get,set,list

$unleashedApiKeySecureString = ConvertTo-SecureString $unleashedApiKeySecretValue -AsPlainText -Force

#Set the Secret Value of Secret 'UnleashedApiKey'.
Set-AzureKeyVaultSecret -VaultName $vaultName -Name $unleashedApiKeySecretName -SecretValue $unleashedApiKeySecureString