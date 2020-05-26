# Let's Encrypt Azure Function Demo
This project was created as a support mechanism for a blog post posted at [https://jasongaylord.com/blog/securing-your-website-for-free](https://bit.ly/2ZBHggD). If you find an error with the code provided, please submit an issue or a pull request.

In the run.csx file, you'll find 13 variables that have been defined and need to be replaced. I've grouped the variables and their values together below.

### General Subscription/Resource Settings
* `SUBSCRIPTION_ID` - This value can be found on nearly any of the individual resources in Azure. You will see it listed as subscription ID and it is in the GUID format. 
* `RESOURCE_GROUP` - All resources within Azure are kept in a resource group. This is the name of the resource group that contains the Azure Web App mentioned below.

### Azure Web App
* `APPSERVICE_APPNAME` - This is the name of the Azure Web App that is running the web application you'd like to secure.

### Azure Function
* `FUNCTION_APP_NAME` - You will create an Azure Function to renew your Let's Encrypt certificate. This is the name of the Azure Function app, not the individual function. It's also the name that you'll find in the URL for the app right before azuerwebsites.net.
* `AZURE_FUNCTION_DEPLOYMENT_USERNAME` - If you choose Get Publish Profile in the Azure Function App, you'll receive a PublishSettings XML file. Contained within this file is a value with the userName. This value (including the dollar sign) should be used.
* `AZURE_FUNCTION_DEPLOYMENT_PASSWORD` - Similar to the username above, this value is contained in the PublishSettings XML file and would be found as the userPWD value.

### Azure Active Directory
For this section, it is recommended that you are a [Global Administrator](https://docs.microsoft.com/en-us/azure/active-directory/users-groups-roles/directory-assign-admin-roles). 
* `AD_APPLICATION_ID` - When you create a new Azure AD Application registration, you'll receive an Application ID. In the Azure Portal, got to Azure Active Directory. Once your directory loads, under Manage, find App Registrations. If nothing loads, you may need to press the button 'View all applications.' Find your application in the list and copy the GUID value under Application ID.
* `AD_APPLICATION_SECRET` - Following the same method above, if you click on your registered application, you'll see a Settings option. When clicking on that, it will open the Settings blade. Find Keys under the API Access settings. You will need to create a new password if you did not copy the value from the previous password created. You will not be able to retrieve this value again.
* `AD_DIRECTORY_ID` - In the Azure Portal, got to Azure Active Directory. Once your directory loads, under Manage, find Properties. Copy the GUID value found in Directory ID. This is the Tenant ID or Directory ID of your Azure Active Directory instance.

### Custom Settings for Your Implementation
* `BASE_URL` - I recommend always using the root domain. So, for example, I use 'jasongaylord.com' for this value.
* `OTHER_URLS` - This can be a single string such as 'www.jasongaylord.com' or you can replace the set of double quotes with a bunch of sub-domains such as {"www.jasongaylord.com","foo.jasongaylord.com"}. Just note that whatever URLs you use here must be contained within the Azure Web App you used above.
* `YOUR_EMAIL` - This can either be a personal email or a service email that will receive Let's Encrypt renewal reminders and service emails.
* `RANDOM_PASSWORD` - Choose a random password to be used to secure the certificate.
