---
title: Analysis of Discovery and Assessments reports
description: Procedure to analyse Discovery and Assessments reports
author: kalrashradha
ms.author: v-ksreedevan
ms.topic: conceptual
ms.date: 12/27/2022
---
# Discovery and Assessment Report Analysis 
Azure Migrate Export (AME) generates the following excel reports to provide discovery and assessment details of a customer’s environment:
- Discovered VMs
- Assessment Core Report
- Assessment Opportunity Report
- Assessment Clash Report

## Discovered VMs
File Path: ```\AzMigExport\All_Discovered-VMs-Report\Discovered_VMs.xlsx```

The Discovered VMs report contains details of all VMs and servers that are discovered in customer’s environment from the selected source type or appliance. The report also outlines the type of workload a VM is running.
Kindly refer to below dictionary for more details:

**Column Name** | **Details**
--- | ---
Machine | Name of the discovered machine. 
MachineArmId |	Unique identifier of machine in Azure.
IPaddress	| IP address of the machine.
Softwareinventory |	Count of discovered software inventory on a machine.
sqlDiscoveryServerCount |	Count of SQL instances running on a machine. <br></br> AME recommends PaaS preferred Migration Strategy and hence, the machines that have SQL instances running on them are first considered for migration to the SQL managed instance. <br></br> If you do not want your machine to be recommended for PaaS target, you can change the value of this column to 0 before starting assessments. [Learn More](how-to-customize-discovery-report) about how to customize discovery report.
sqlServicePresent | The column value is 1 if SQL services such as SQL Server Integration Services, SQL Server Report Services, and SQL Server Analysis Services are present on the machine.<br></br> AME recommends migrating such servers to Azure VMs. If you do not want your machine to have a VM recommendation for Servers containing SQL Services, you can set the respective column value to 0. [Learn More](how-to-customize-discovery-report) about how to customize discovery report.
WebappsCount |	Count of Web apps running on a machine. <br></br> AME recommends PaaS preferred Migration Strategy and hence, the machines that have Web apps running on them are first considered for migration to App Service. <br></br>If you do not want your machine to be recommended for PaaS target, you can change the value of this column for the respective machine to 0 before starting assessments. [Learn More](how-to-customize-discovery-report) about how to customize discovery report. 
Cores | Count of vCores in the machine.
Memory(MB) |	Memory size of the machine.
TotalDisks |	Total disks in the machine.
OperatingSystem	| Operating System running on the machine.
TotalNetworkadapters	| Count of Network adaptors present in the machine.
Boottype |	Boot Type of the machine.
MACaddress |	MAC address of the machine.
Powerstatus	| Status of the machine at the time of discovery, that is, *ON*, *Running*, or *Powered Off*.
Lastupdatedtime |	Date and time when last discovery data was received by Azure Migrate Appliance.
Firstdiscoverytime |	Date and time when collection of discovery data began by Azure Migrate Appliance.
EnvironmentType	| This column is for user inputs. <br></br> Users can categorize the servers into dev and prod environments by entering information into this column so that adequate pricing considerations are applied at the time of assessment. Servers where environment type cells are blank are considered as production servers by default. <br></br> Permitted User input values: “Dev” and “Prod”. [Learn More](how-to-customize-discovery-report) about how to customize discovery report.
Target | Region	Target regions selected by user while running discovery on AME.

## Assessment Core report
File Path: ```\AzMigExport\Core-Report\AzureMigrate_Assessment_Core_Report.xlsx```.

The Assessment Core report contains all the information about servers and workloads and the targets that are ready to be migrated to Azure with minimal changes. The focus here is on a PaaS first approach such that if the customer’s SQL Server instances or .NET Web Apps running on IIS web servers are ready for Azure SQL Managed Instance and Azure App Service respectively, they will be considered for those targets unless scoped out of the consideration set before running Assessment module in AME. SQL Server instance and .NET Apps that are not ready for PaaS, as well as remaining workloads and servers, including those running other SQL Services such as SQL Server Analysis Services, are sized for Azure VM. In addition to SKUs and ready to be migrated workloads, core report covers estimated prices considering various options considering offers such as Pay-as-you-go, reservations, and Azure Hybrid Benefit for Windows and SQL. These are run on in-scope servers. 

The definition of reports that are part of Assessment Core report are as follows: 

**Report Name** | **Details**
--- | ---
SQL_MI_PaaS |	All the in-scope discovered SQL instances are first assessed for Azure SQL Managed Instances. The report contains details of SQL Instances that are ready for Azure SQL Managed Instance, readiness warnings (if any), recommended MI Configuration, properties of SQL Instance, and various estimated cost considering offers such as Pay-as-you-go, reservations, and Azure Hybrid Benefit for both Dev and Prod environment.
SQL_MI_Warnings	| The report contains details of readiness warnings for SQL instances that are ready for Azure SQL Managed Instance. 
SQL_IaaS_Instance_Rehost_Perf	| The in-scope discovered SQL Instances that cannot be migrated to Azure SQL MI due to migration blockers (details of which are available in the Opportunity report) are then assessed for readiness of SQL Instances to Azure VM. The report contains details of performance-based assessment of the remaining SQL instances that are ready for Azure VM, readiness warnings (if any), recommended Azure VM Configuration, performance properties of VM, and various estimated cost considering offers such as Pay-as-you-go, reservations, and Azure Hybrid Benefit for both Development and Product environments. Only Premium disks are recommended for Storage in such assessment. The report also contains estimated cost for Azure Site recovery and Azure Backup for SQL Instances in Prod environment. 
SQL_IaaS_Server_Rehost_Perf	| The in-scope discovered SQL servers whose SQL Instance or instances can neither be migrated to Azure SQL MI nor can be migrated to Azure VM are then assessed for readiness of SQL Server to Azure VM. The report contains details of performance-based assessments of such SQL servers that are ready for server rehost to Azure VM, readiness warnings (if any), recommended Azure VM Configuration, performance properties of VM, and various estimated cost considering offers such as Pay-as-you-go, reservations, and Azure Hybrid Benefit for both Development and Product environments. The report also contains estimated cost for Azure Site recovery and Azure Backup for servers in Prod environment.
SQL_IaaS_Server_Rehost_As-is	| The in-scope discovered  SQL servers whose consisting SQL Instance or instances can neither be migrated to Azure SQL MI nor can be migrated to Azure VM  are then assessed for readiness of SQL Server to Azure VM. The report contains details of As-Onprem assessment of such SQL servers that are ready server rehost to Azure VM, readiness warnings (if any), recommended Azure VM Configuration, performance properties of VM, and estimated cost on Azure for both Dev and Prod environments.
WebApp_PaaS	| All the in-scope discovered Web app Servers are first assessed for Azure App Services. The report contains details of Web apps that are ready for Azure App Services, readiness warnings and issues (if any), recommended App Service Plan, properties of Web app server, and various estimated cost considering offers such as Pay-as-you-go, reservations, and Azure Hybrid Benefit for both Development and Production environments.
WebApp_IaaS_Server_Rehost_Perf	| The in-scope discovered Web app Server whose web app/web apps cannot be migrated to Azure App Service due to migration blockers (details of which are available in opportunity report) are then assessed for Server rehost to Azure VM. The report contains details of performance-based assessment of such Web app servers, its readiness warnings (if any), recommended Azure VM Configuration, performance properties of VM, and various estimated cost considering offers such as Pay-as-you-go, reservations, and Azure Hybrid Benefit for both Development and Production environments. The report also contains estimated cost for Azure Site Recovery and Azure Backup for servers in Prod environment.
WebApp_IaaS_Server_Rehost_As-is |	The in-scope discovered Web app Servers whose web app/web apps cannot be migrated to Azure App Service due to migration blockers (details of which are available in opportunity report) are then assessed for Server Rehost to Azure VM. The report contains details of As-Onprem assessment of such Web app servers, its readiness warnings (if any), recommended Azure VM Configuration, performance properties of VM, and estimated cost on Azure for both Dev and Prod environment.
VM_SS_IaaS_Server_Rehost_Perf	| The in-scope VMs that have SQL services running such as SQL Server integration services, SQL Server reporting services are assessed for migration to Azure VM. The report contains details of perf-based assessment of such VMs, its readiness warnings (if any), recommended Azure VM Configuration, performance properties of VM, and various estimated cost considering offers such as Pay-as-you-go, reservations, and Azure Hybrid Benefit for both Dev and Prod environments. The report also contains estimated cost for Azure Site Recovery and Azure Backup for servers in Prod environment.
VM_SS_IaaS_Server_Rehost_As-is	| The in-scope VMs that have SQL services running such as SQL Server integration services, SQL Server reporting services are assessed for migration to Azure VM. The report contains details of As-Onprem of such VMs, its readiness warnings (if any), recommended Azure VM Configuration, performance properties of VM, and estimated cost on Azure for both Dev and Prod environment.
VM_IaaS_Server_Rehost_Perf	| The in-scope VMs that doesn’t have SQL Server, Web app or SQL Services present on them are assessed for migration to Azure VM. The report contains details of performance-based assessment of such VMs, its readiness warnings (if any), recommended Azure VM Configuration, performance properties of VM, and various estimated cost considering offers such as Pay-as-you-go, reservations, and Azure Hybrid Benefit for both Dev and Prod environments. The report also contains estimated cost for Azure Site Recovery and Azure Backup for servers in Prod environment.
VM_IaaS_Server_Rehost_As-is |	The in-scope VMs that doesn’t have SQL Server, Web app, or SQL Services present on them are assessed for migration to Azure VM. The report contains details of perf-based assessment of such VMs, its readiness warnings (if any), recommended Azure VM Configuration, performance properties of VM, and estimated cost on Azure for both Dev and Prod environment.
SQL_All_Servers |	The report contains details of perf-based assessment of all in-scope SQL Servers, its recommended target, readiness warnings (if any), performance properties of SQL Instance, and various estimated cost considering offers such as Pay-as-you-go, reservations, and Azure Hybrid Benefit for both Dev and Prod environment.
AllVM_IaaS_Server_Rehost_Perf |	The report contains details of perf-based assessment of all in-scope VMs, its readiness warnings (if any), recommended Azure VM Configuration, performance properties of VM, and estimated cost on Azure for both Dev and Prod environment.

## Assessment Opportunity report
File Path: ``` \AzMigExport\Opportunity-Report\AzureMigrate_Assessment_Opportunity_Report.xlsx```.
The opportunity report helps one identify additional modernization opportunities for SQL Server instances and .NET Web apps, by indicating what blockers or issues customers must address to be able to fully modernize SQL Server and .NET workloads. 
Additionally, Opportunity report also covers details of alternate migration paths for VMware based servers, by indicating cost, readiness and SKUs for Azure VMware Solution (AVS). These are run on in-scope servers. 

The definition of reports that are part of Assessment opportunity report are as follows: 

**Report Name** | **Details**
--- | ---
AVS_Summary |	All the servers hosted in a VMware environment can be migrated to Azure VMware Service (AVS). Rehosting VMware on AVS is an alternate approach to PaaS preferred migrations.The report contains a Summary of AVS assessment, readiness issues and warnings (if any), recommended Node type, number of nodes, and various estimated cost considering offers such as Pay-as-you-go, reservations for both Dev and Prod environments. Dev/Test Pricing is not applicable for AVS. AVS_IaaS_Rehost_Perf tab contains the details of this assessment.
AVS_IaaS_Rehost_Perf	| The report contains details of in-scope VMs that were assessed for AVS such as readiness issues and warnings (if any), VM performance properties for both Dev and Prod environments.
SQL Opportunity	| The report contains details of in-scope SQL Server instances that cannot be migrated to Azure SQL Managed Instance. The report highlights recommended Azure MI configuration (if SQL instance was ready with conditions for Azure SQL MI), details of issues and warnings that needs to be remediated to make SQL instances ready for Azure SQL MI.
SQL Issues & Warnings |	The report contains details of in-scope SQL Server instances that cannot be migrated to Azure SQL Managed Instance. The report details of issues and warnings that needs to be remediated to make SQL instances ready for Azure SQL MI.
Webapp Opportunity |	The report contains details of in-scope Web app that cannot be migrated to Azure App Service. The report highlights details of issues and warnings that needs to be remediated to make Web app ready for Azure App Service. 
VM Opportunity_Perf |	The report contains details of in-scope VMs that cannot be migrated to Azure. The report highlights details of issues and warnings that needs to be remediated to make VM ready for Azure VM.

## Assessment Clash report
File Path: ```\AzMigExport\Clash-Report\AzureMigrate_Assessment_Clash_Report.xlsx```.

The Clash report helps to identify duplicates within the Core report. With this report, users can customize the Assessment Core report by deleting unwanted servers in an assessment. This helps a user generate precise estimated cost of customer’s workloads in Azure.

The Clash report highlights count and details of assessments conducted for a machine that is sized for assessments.

### Interpreting Clash report

![Screenshot of clash report.](./.media/clash-report.png)

In the example above, the machine CRMSQLVM14 has two entries in SQL_IaaS_Instance_Rehost_Perf tab and one entry in SQL_MI_PaaS tab, and one entry in SQL_IaaS_Server_Rehost_Perf tab. This report can be used as a tally to understand a summary of all the in-scope machines and the user can customize the Assessment Core report to get the required cost estimate output from PowerBI. [Learn More](#how-to-customize-assessment-core-report) on how to customize the Assessment Core Report.

## Understanding PowerBI report
The details of each slide in data populated PowerBI report is as follows: 
**Slide** | **Details**
--- | ---
3	| Contains an overview of key metrics and summarization of respective parameters of all discovered VMs.
5	| Contains summary of Migration Target, Azure Recommendation, and respective estimated cost for customer’s environment.
6	| Contains details of the Windows server and SQL Server that customer needs to prioritize in migration as the server Windows and SQL License is either Unsupported or in Extended Support. 
7, 14, 15	| Contains aggregated details of VMs and SQL Instances that are ready for Azure VM (IaaS). This contains details from the following assessments: “VM_IaaS_Server_Rehost_Perf”, “SQL_IaaS_Instance_Rehost_Perf”, “SQL_IaaS_Server_Rehost_Perf”, “WebApp_IaaS_Server_Rehost_Perf” and “VM_SS_IaaS_Server_Rehost_Perf”.
8, 17	| Contains aggregated details of SQL Instances that are ready for Azure Managed Instance.
9, 18	| Contains aggregated details of Web apps that are ready for Azure App Service.
10	| Azure Site Recovery and Backup details of all production servers that are not ready for PaaS services.
11	| Gives an estimate of cost in customers Dev/Test environment and the estimated Saving.
23, 24	| Aggregated Details of SQL instances that are not ready for Azure SQL MI.
26	| Aggregated Details of Web app that are not ready for Azure App Service.
28, 29	| Aggregated details of AVS assessment. Contains details from “AVS_Summary” and “AVS_IaaS_Rehost_Perf” tabs in Opportunity report.
31-34	| Details benefit of Azure Hybid benefits offer.
37, 38	| Details benefit of Reserved Instances offer.