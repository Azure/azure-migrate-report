---
title: Run Azure Migrate Export reports without customization
description: Get an overview of running AME reports with customization.
author: kalrashradha
ms.author: v-ksreedevan
ms.topic: tutorial
ms.date: 12/27/2022
---

# Run Azure Migrate Export without customization
This article describes the procedure to run Azure Migrate Export without customizations.

### Prerequisites 
- Review the prerequisites for running Azure Migrate Export.
- Before running Azure Migrate Export, users must have successfully set up an Azure Migrate Project, deployed an Azure Migrate appliance, and should have successfully performed discovery using the Azure Migrate: Discovery and Assessment tool.
- There are two workflows in which users can run Azure Migrate Export Utility.
   - Run without Customization or Single Click Experience - Aims to quickly generate required output with certain assumptions such as all machines discovered are in-scope and belong to Production environment.
   - Run with Customization - Aims to allow for customization such as classification of environment such as dev/prod to take advantage of Dev/Test pricing, moving machines out of scope for an assessment or moving machines out of scope of migration and even the visualization. [Learn More](#how-to-customize-discovery-report) on how to customize Discovery file.

### Run Azure Migrate Export
Azure Migrate Export without customization quickly generates required output with certain assumptions such as all Machines discovered are in-scope and belong to Production environment. 
Follow the below steps:
1. Download the Azure Migrate Export utility package and extract the contents on the package. [Learn More](#how-to-get-azure-migrate-export-utility-package) about how to get Azure Migrate Export Utility Package.
2. Run the Azure Migrate Export application.
3. To generate the Discovery and assessment reports with customization, select **Workflow** option as **Both**.
4. In **Azure Migrate source appliance**, select the source of servers. By default, all three sources, namely VMware, Hyper-V, and Physical are selected.
5. Enter the project identifier details such as Tenant ID, Subscription ID, Resource Group name, Discovery Site name and assessment project name. [Learn More](#how-to-find-project-discovery-and-assessment-parameters) on where to find the Project Identifier.
6. Select the **Target location** where you want to modernize your resources, the **Assessment duration** for which you want to run assessment, and select **Submit**.
7. Users will now be prompted to authenticate Azure access.
8. Once the user is authenticated in Azure, the discovery and assessment modules both run in sequence to generate discovery Report, Assessment Core Report, Assessment Opportunity Report and Assessment Clash Report. [Learn More](#discovery-and-assessment-report-analysis) about highlights of the report.
   > [!Note] 
   > An assessment typically runs in 1-2 hours but may take more time to run depending on the size of environment.
9. Users can choose to customize assessment report for removing required duplicates in assessment. [Learn More](#how-to-customize-assessment-core-report) about how to customize assessment reports.
10. Run the “Azure_Migrate_Export.pbit” PowerBI template provided in the Utility package.
11. Provide the path of utility package where all the reports are generated and click Load. [Learn More](#how-to--find-basepath) about base Path.
12. Once the data is loaded, Users can now choose to change static data in PowerBI report to customize as per requirement. [Learn More](#how-to-customize-powerbi-report) about how to customize PowerBI Report.
13. After finalizing the slides, publish the PowerBI report on your workspace.
   ![Screenshot of PowerBI workspace.](./.media/workspace-report.png)
14. You can download the Azure Migrate Export Executive Presentation as PPT from your workspace.
   ![Screenshot of embed image option.](./.media/embed-image.png)


