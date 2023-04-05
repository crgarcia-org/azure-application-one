locals {
  prefix   = "crgar-aks-advance"
  location = "switzerlandnorth"
}

terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "3.37.0"
    }
  }
  backend "azurerm" {
    resource_group_name  = "crgar-aks-advance-terraform-rg"
    storage_account_name = "crgaraksadvancetfstate"
    container_name       = "tfstate"
    key                  = "terraform.tfstate"
  }
}
provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "spoke_rg" {
  name     = "${local.prefix}-rg"
  location = local.location
}

module "aks" {
  source              = "./modules/aks"
  prefix              = local.prefix
  location            = local.location
  resource_group_name = azurerm_resource_group.spoke_rg.name
  resource_group_id   = azurerm_resource_group.spoke_rg.id
}
