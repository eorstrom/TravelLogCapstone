# Travel Log Capstone

### Description
This app is my full-stack cummulative project for the Nashville Software School program. It's goal is to be able to allow users to track their visits to different locations, such as restaurants, museums, parks, and the like and write a personal review for reference later. Like a journal entry. For MVP purposes, I stuck with only searching for and saving restaurant names and addresses to the database.

As of writing this README on July 5th, 2016, the app is in it's very early stages of development. It can so far interact with a Google Map on the main page, and use the autocomplete function to search for places matching the string that a user types in, and then pull up the basic information (Name of location and Address) for that location when the user clicks on its icon on the map. The user should then type in the name of the location (sticking with restaurants as a start) and the location's address. Upon clicking the 'Add Location' button, the information for that restaurant is then saved to the database. When the user refreshes the page and clicks the 'See Your Lists' link, the added information should then appear on the page under 'Want to Visit'. (Currently I am trying to fix a bug in which the information is not displayed on the page.)

Future plans for upgrades to be made: 

1. Either bind the input fields to the search results so that a user doesn't have to type in the data that comes back from a search result in order to add it to their 'Want to Visit List', or execute the save to list functionality with a save location button.
2. Show a confirmation message that the location has successfully been added to the database, or an error message if there was an error.
3. After the location has been added, show the added information in the list without the user needed to refresh the page.

### How to Run
This repo should be cloned along with my TravelLogCapstone repo. This repo is for the front-end, user interaction. The other repo is the backend database for saving user input.   

1. Clone the Travel-Log-Capstone-Client repo.
2. 

