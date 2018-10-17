# SalesforceToUnleashed
![Build status](https://harriskristanto.visualstudio.com/ACSUG%20Demo/_apis/build/status/ACSUG%20Demo-ASP.NET-CI)
<br/>
<br/>
A demo for Auckland Connected Systems User meetup group.<br/>
This solution uses Salesforce connector in Logic App to capture newly created customer records in Salesforce, then using Azure Functions to convert the Salesforce JSON message to Unleashed Customer message and create new customer record via Unleashed's REST API.<br/>
It only supports the transfer of Salesforce Account to Unleashed Customer at this stage.<br/>
<br/>
-Salesforce: https://www.salesforce.com/<br/>
-Unleashed Software: https://www.unleashedsoftware.com/<br/>
-Unleashed API Docs: https://apidocs.unleashedsoftware.com/<br/>
