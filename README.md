# Music Cat

## Introduction
Music Cat is a Web API developed by a team of four students as a final project for the Eleven Fifty Academy: Blue Badge. The application is meant to emulate a music catalog where the user is able to add, view, update, and delete items from data tables of Artists, Albums, Songs, and Genres. Using foreign key relationships, Artists could be linked to multiple Albums, Albums to multiple songs, and both Albums and/or Songs could be affiliated with a Genre. Along with these foreign key relationships, the group was to demonstrate a competency in using Entity Framework, REST API, and N-Tier Architecture.

Collaborators on this project include: James Hemphill ([jhemphill1389](https://github.com/jhemphill1389)), Betsy Hollis ([Bhollis1](https://github.com/bhollis1)), Tom Rambo ([trambo63](https://github.com/trambo63)), and Gabe Soliman ([gmsoliman](https://github.com/gmsoliman)).

## Directions for Running Locally
In order to run the app locally, you'll need to use an API testing tool. For the development of this API, our team utilized Postman to run and test our endpoints, so for the purposes of this guide, we will be explaining how to locally run the different endpoints using Postman.

### Installing Postman
If you don't already have Postman installed, go [here](https://learning.postman.com/docs/getting-started/installation-and-updates/) to follow steps on how to install and update it on your specific system.

### Getting Started
After cloning the repository, run the program, and you should see API documentation in your default browser. In the URL, you'll find the link for the Web API which you'll be using in Postman. It should look something like **localhost:XXXXX**.  Click on API in the navbar to view all the different endpoints that are available. Each endpoint shows the path that you would need to add to the end of the URL in order to utilize that endpoint. For example, if you wanted to create an account, you would use the POST api/Account/Register endpoint by adding it to the end of your localhost URL i.e. **localhostXXXXX/api/Account/Register** and changing the request to a POST request. By clicking on an endpoint, you can view more information on the endpoint such as URI parameters, body parameters, or request formats which can guide you on how to utilize said endpoint in Postman.

### API Account Registration
This API uses Individual User Accounts for authentication, so in order to begin testing different endpoints, you'll have to create a user account first. The following steps will walk you through how to set up an account and claim an authentication token.

1. While the program is running, open Postman and create a new request by clicking the ```+``` at the top of the page. You should see a view similar to this:
![New Request View](https://github.com/gmsoliman/MusicCatREADMEAssets/blob/main/newrequest.PNG)

2. In the request URL, enter **localhost:XXXXX/api/Account/Register** and change the request type to **POST**.

3. Go to the body tab and make sure that **x-www-form-urlencoded** is selected.

4. If you reference the endpoint in the ASP.net webpage, you will see how to input your user information in the body by viewing the table in the body parameters. The **Name** column will be your KEY in Postman, and the **Type** indicates the type of value you must enter under the VALUE column in Postman. Note that the password you enter must have at least one uppercase letter, a number, and a symbol.

5. Once your body tab looks like the example below, you may hit send.
![Account Register Example](https://github.com/gmsoliman/MusicCatREADMEAssets/blob/main/accountregister.PNG)

You should have gotten a 200 OK response back. Next, you'll request the authentication token.

1. Add **/token** to the URL (it should look like: **localhost:XXXXX/token**), and make sure your request is set to **GET**.

2. In the body tab, input the same email and password you registered with for your username and password. In addition, you'll need to input the **grant_type** as shown below:
![Token Request](https://github.com/gmsoliman/MusicCatREADMEAssets/blob/main/token.PNG)

3. Go to the **Headers** tab and check **Content-Type**, then press **Send**.

4. You should see an access token in the response window. Copy the token.

5. In the headers tab, add a header with the key "Authorization" (no quotes) and set the value to "Bearer [your token]" (no quotes or brackets). It should look like the following:
![Authorization Example](https://github.com/gmsoliman/MusicCatREADMEAssets/blob/main/tokenrequest.PNG)

Now you're able to make requests and utilize the endpoints of the API!

### Utilizing Endpoints
While using the endpoints in Postman, it's important to reference the API documentation. This not only shows what to add to your localhost URL for the request, it also provides crucial information such as URI parameters, which can be used for GET/DELETE requests, or Body parameters, which show what properties you're required to or can opt to add for POST/PUT requests. Below you'll find some examples of how certain endpoints can be run.

#### GET All
To view all items in a data table, a GET all request can be made. To do this simply, add the endpoint path to the end of the request URL, set the request to **GET**, and click **Send**. Below is an example:
![GET All Example](https://github.com/gmsoliman/MusicCatREADMEAssets/blob/main/getallsongs.PNG)

#### GET by ID
To view a specific item in a data table, a GET by ID request can be made. This is done similarly to a GET all request, but the ID number of the specific item you wish to view needs to be added to the end of the request URL. Below is an example:
![GET by ID Example](https://github.com/gmsoliman/MusicCatREADMEAssets/blob/main/getbyid.PNG)

#### POST
A **POST** request can be used to add an item to a data table. For this type of request, it's important to reference the API documentation in order to know what properties can be or are required to be added to the body tab in order to be created. The example below shows the API documentation and the Postman input needed to make a **POST** request for an Artist.
![POST API documentation](https://github.com/gmsoliman/MusicCatREADMEAssets/blob/main/postapidoc.PNG)
![POST Request Example](https://github.com/gmsoliman/MusicCatREADMEAssets/blob/main/postexample.PNG)

#### PUT
A **PUT** request is used to update/change an existing item in a data table. Making this request is similar to making a **POST** request, only the ID number of the item you wish to edit needs to be added to the end of the request URL. The **Keys** and **Values** in the body tab should reflect the properties that you intend the data item to have once the request is made. Below is an example:
![POST Request Example](https://github.com/gmsoliman/MusicCatREADMEAssets/blob/main/putexample.PNG)

#### DELETE
Finally, a **DELETE** request is used to delete an item from the data table. Making this request is the same as making a **GET** by ID request (add the endpoint path to the end of the request url as well as the item's ID number), only you need to make sure to switch the request to **DELETE**. Below is an example:
![DELETE Request Example](![POST Request Example](https://github.com/gmsoliman/MusicCatREADMEAssets/blob/main/deleteexample.PNG)

## Resources Used
Below are some resources that the group found useful while working on this project:
* [APIs for Beginners](https://www.youtube.com/watch?v=GZvSYJDk-us&t=2962s)
* [What Are APIs and How Do They Work?](https://www.programmableweb.com/api-university/what-are-apis-and-how-do-they-work)
* [REST API Tutorial](https://restfulapi.net/)
* [Configure One-to-Many Relationship in code-first approach](https://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx)
* [Git Tutorial for Beginners](https://www.youtube.com/watch?v=uIa9CejUcQM)
