# RecipeSharingApi
Backend API for Recipe Sharing

There are any number of existing websites that allow you to search for recipes, so what makes this one so differnt?

* Upload our own recipes without having to scour the web each time
* Ability to add and edit our recipes with the option to keep them private or share them with others
  * Private
  * Share with specific users
  * Share with specific groups
  * Share with all
* Ability to create Recipe Books that include recipes selected from recipes
  * Added by you
  * Shared with you
  * Shared with a group you belong to
  * Shared with all
* Ability to copy an existing recipe and change the recipe
  * The new recipe will be owned by you
  * Track each location it was copied from
* The API will be able to be consumed by other services
  * Allowing it to be used in many environments for different purposes

# Repositories
* [RecipeSharingApi](https://github.com/mariekauth/RecipeSharingApi)
  * Stores the code for the API
  * An unsecure development version of the API can be found [here](http://recipesharingapi.kauths.com/)
* [RecipSharingDatabase](https://github.com/mariekauth/RecipeSharingDatabase)
  * Stores the script files for creating the empty database
  * May also include the files for seeding the data
* [RecipeSharingClientIos](https://github.com/mariekauth/RecipeSharingClientIos)
  * Code for the Native Ios Mobile

# Instructions for obtaining raw code and contributing to the project
* Fork each of the above repositories (or the ones you wish to contribute to)
* Create a folder to contain the whole project, then clone each repo
* The following method clones the original repo, and sets it as upstream
```
   mkdir RecipeSharing
   cd RecipeSharing
   git clone -o upstream git@github.com:mariekauth/RecipeSharingApi.git
   git clone -o upstream git@github.com:mariekauth/RecipeSharingDatabase.git
   git clone -o upstream git@github.com:mariekauth/RecipeSharingClientIos
```

* Add remotes for your fork - origin (your repo)
```
   cd RecipeSharingApi
   git remote add upstream git@github.com:{yourGitHubUser}/RecipeSharingApi.git

   cd ../RecipeSharingDatabase
   git remote add upstream git@github.com:{yourGitHubUser}/RecipeSharingDatabase.git

   cd ../RecipeSharingClientIos
   git remote add upstream git@github.com:{yourGitHubUser}/RecipeSharingClientIos

   cd ..
```

# Still needed to discuss how we are pulling the code in
* Option: Push branches to upstream and then merge into upstream/main
* Option: Push branches to origin and then merge into upstream/main

# Important NOTES:
* Whatever branch we merge to, is the branch the new code should be based off
* The fork gives you full control over your workflow and how you want to handle things later
* Since this is new and each current contributor is working on their own work, the chance of overwrite is slim
* I prefer working off a branch and doing a Pull Request to main
* However, currently working directly off main and pushing to main works because it is new

**This is a DRAFT**
