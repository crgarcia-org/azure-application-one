locals {
  prefix   = "crgar-crgarciaorg-appone"
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
    resource_group_name  = "crgar-crgarciaorg-appone-tf-rg"
    storage_account_name = "crgarciaorgapponetf"
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
  source              = "github.com/crgarcia-org/azure-ccoe-terraform-modules/azure-kubernetes-service/v1.0"
  prefix              = local.prefix
  location            = local.location
  resource_group_name = azurerm_resource_group.spoke_rg.name
  resource_group_id   = azurerm_resource_group.spoke_rg.id
}
