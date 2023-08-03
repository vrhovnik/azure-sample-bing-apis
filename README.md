# Sample repository about using Bing Cognitive Services API

The Bing Search APIs let you build web-connected apps and services that find webpages, images, news, locations, and more
without advertisements. By sending search requests using the Bing Search REST APIs or SDKs, you can get relevant
information and content for web searches. Use this article to learn about the different Bing search APIs and how you can
integrate cognitive searches into your applications and services.

In this repository we will demonstrate the usage with having a simple web application that will use the Bing Search API:

1. [Bing Web Search API](https://docs.microsoft.com/en-us/azure/cognitive-services/bing-web-search/overview) - demos page [here](https://www.microsoft.com/en-us/bing/apis/bing-web-search-api)
2. [Bing Image Search API](https://docs.microsoft.com/en-us/azure/cognitive-services/bing-image-search/overview) - demos page [here](https://www.microsoft.com/en-us/bing/apis/bing-image-search-api)
3. [Bing Entity Search API](https://docs.microsoft.com/en-us/azure/cognitive-services/bing-entities-search/overview) - demos page [here](https://www.microsoft.com/en-us/bing/apis/bing-entity-search-api)
4. [Bing News Search API](https://learn.microsoft.com/en-us/azure/cognitive-services/bing-news-search/concepts/search-for-news) - demos page [here](https://www.microsoft.com/en-us/bing/apis/bing-news-search-api)
5. [Bing Video Search API](https://docs.microsoft.com/en-us/azure/cognitive-services/bing-video-search/overview) - demos page [here](https://www.microsoft.com/en-us/bing/apis/bing-video-search-api)
6. [Bing Visual Search API](https://docs.microsoft.com/en-us/azure/cognitive-services/bing-visual-search/overview) - demos page [here](https://www.microsoft.com/en-us/bing/apis/bing-visual-search-api)
7. [Bing Autosuggest API](https://learn.microsoft.com/en-us/azure/cognitive-services/bing-autosuggest/get-suggested-search-terms)
8. [Bing Spell Check API](https://docs.microsoft.com/en-us/azure/cognitive-services/bing-spell-check/overview) - demos page [here](https://www.microsoft.com/en-us/bing/apis/bing-spell-check-api)

It will integrate the API inside the app to demonstrate the usage in the app itself.

## Prerequisites

1. an active [Azure](https://www.azure.com) subscription - [MSDN](https://my.visualstudio.com) or trial
   or [Azure Pass](https://microsoftazurepass.com) is fine - you can also do all of the work
   in [Azure Shell](https://shell.azure.com) (all tools installed) and by
   using [Github Codespaces](https://docs.github.com/en/codespaces/developing-in-codespaces/creating-a-codespace)
2. [Subscription key from Azure Portal](https://learn.microsoft.com/en-us/bing/search-apis/bing-web-search/create-bing-search-service-resource#create-your-bing-resource)
2. [PowerShell](https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell-on-windows?view=powershell-7.2)
   installed - we do recommend an editor like [Visual Studio Code](https://code.visualstudio.com) to be able to write
   scripts, YAML pipelines and connect to repos to submit changes.
3. [OPTIONAL] [Windows Terminal](https://learn.microsoft.com/en-us/windows/terminal/install) to be able to work with
   multiple terminal Windows with ease

If you will be working on your local machines, you will need to have:

1. [Powershell](https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell-on-windows)
   installed
2. git installed - instructions step by step [here](https://docs.github.com/en/get-started/quickstart/set-up-git)
3. [.NET](https://dot.net) installed to run the application if you want to run it locally
4. an editor (besides notepad) to see and work with code and more (for
   example [Visual Studio Code](https://code.visualstudio.com) or [NeoVim](https://neovim.io/)
   or [Visual Studio](https://visualstudio.microsoft.com/) or [Jetbrains Rider](https://www.jetbrains.com/rider/))

To control settings, we recommend to use [environment variables](https://12factor.net/config). The easiest way to set
them is via PowerShell and
his [provider](https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_providers?view=powershell-7.3)
option.

```powershell

Set-Content env:\$name $value

```

Check out [appsettings.json](BingSamplesSolution/BingSamples.Web/appsettings.json) to see what settings are needed.

For example:

```powershell

Set-Content env:\App__SubscriptionKey "YourSubscriptionKeyYouGetFromAzure"

```

You can check out [docs for dotnet run](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-run) for more options
how to run the app with parameters.

If you want to automate the process, you can use PowerShell script to prepare the environment for you with *.env files.

```powershell

Get-Content $PathToENVFile | ForEach-Object {
    $name, $value = $_.split('=')
    Set-Content env:\$name $value
}

```

Open PowerShell and run the upper command by replacing PathToENVFile the path to your file in double quotes.

When all settings are set, you can run the application with dotnet run command.

Example below:

```powershell

dotnet run

```

Open the browser on URL presented to you on the screen and you should see the application running.

![App is running on localhost](https://webeudatastorage.blob.core.windows.net/web/bing-api-samples-localhost.png)

## Run it in postman

If you want to explore REST api calls, I have added [postman collection](Extras/Bing%20APIs.postman_collection.json). To
run it, you will need to install client side tool [Postman](https://www.postman.com/downloads/).

After install, open postman:
1. use Import option from File menu (File -- Import or press CTRL+O)
2. select files and save it in collection.
3. Change the key and update Authorization tab, which you get from Azure portal (when you create resource)

![Bing authorization information](https://webeudatastorage.blob.core.windows.net/web/Bing-Apis-Key-Postman.png)

4. test out the api's

## Links and additional information

1. [Bing Search API overview](https://docs.microsoft.com/en-us/azure/cognitive-services/bing-web-search/overview)
2. [Bing Search API pricing](https://azure.microsoft.com/en-us/pricing/details/cognitive-services/search-api/)
3. [Bing usage and guidelines](https://learn.microsoft.com/en-us/azure/cognitive-services/bing-web-search/use-display-requirements)
