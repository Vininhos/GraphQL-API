### GraphQL-API

This project was built to learn and understand the GraphQL concepts and tools.

### How to try it?

You can run the project cloning it and then using Docker and Docker Compose.

1. Clone the project.
   
   ```git
   git clone https://github.com/Vininhos/Books-Storage.git
   ```

2. Open CommanderGQL folder.
   
   ```
   cd CommanderGQL
   ```

3. Run Docker Compose.
   
   ```docker
   docker compose up
   ```

4. Access the http://localhost:8080/graphql on your browser/api tool.

5. With BananaCakePop open, click on **Create Document**.
   
   ![Screenshot from 2024-02-18 10-38-49.png](/home/viniciusrw/Pictures/Screenshots/Screenshot%20from%202024-02-18%2010-38-49.png)

6. On **Operations**, write some GraphQL queries. Example: Add a Platform named Ubuntu.
   
   ```graphql
   mutation {
     addPlatform(input: {
       name:"Ubuntu"
     })
     {
       platform 
       {
         id 
         name
       }
     }
   }
   ```

7. Get all the platforms from Database with GraphQL.
   
   ```graphql
   query {
     platform {
       id
       name
     }
   }
   ```

Inside **Bruno Requests** folder, there's some queries builded with [Bruno]([GitHub - usebruno/bruno: Opensource IDE For Exploring and Testing Api&#39;s (lightweight alternative to postman/insomnia)](https://github.com/usebruno/bruno)). You can use this tool to test even more the GraphQL API.


