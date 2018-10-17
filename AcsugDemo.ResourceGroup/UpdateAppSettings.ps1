Param(
  [string]$myResourceGroup,
  [string]$Site,
  [string]$vaultName,
  [string]$unleashedApiKeySecretName
)

$webApp = Get-AzureRmWebApp -ResourceGroupName $myResourceGroup -Name $Site
$appSettingList = $webApp.SiteConfig.AppSettings
$hash = @{}

#Retrieve KV secret object from Azure KV
$unleashedApiKeyKvSecret = Get-AzureKeyVaultSecret -VaultName $vaultName -Name $unleashedApiKeySecretName

ForEach ($kvp in $appSettingList) {
  $hash[$kvp.Name] = $kvp.Value
}

#Set the URL to the Key Vault secret on the App Settings.
$hash['UnleashedApiKey-SecretUrl'] = $unleashedApiKeyKvSecret.Id
Write-Host "Now updating app setting: UnleashedApiKey-SecretUrl"

Set-AzureRMWebApp -ResourceGroupName $myResourceGroup -Name $Site -AppSettings $hash