using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace COMP306_Project_Backend.Models
{
    public static class TableOperations
    {

        public static async Task CreateVisitorTable(AmazonDynamoDBClient client)
        {

            await Task.Run(() =>
            {
                client.CreateTableAsync(new CreateTableRequest
                {
                    TableName= "User",
                    ProvisionedThroughput= new ProvisionedThroughput { ReadCapacityUnits=5,WriteCapacityUnits=5},
                    KeySchema=new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName="Email",
                            KeyType=KeyType.HASH
                        }
                    },
                    AttributeDefinitions= new List<AttributeDefinition>
                    {
                        new AttributeDefinition{AttributeName="Email",AttributeType=ScalarAttributeType.S}
                    }

                });
                Thread.Sleep(5000);
            });
        }

        public static async Task CreateLogTable(AmazonDynamoDBClient client)
        {
            await Task.Run(() =>
            {
                client.CreateTableAsync(new CreateTableRequest
                {
                    TableName = "Log",
                    ProvisionedThroughput = new ProvisionedThroughput { ReadCapacityUnits = 5, WriteCapacityUnits = 5 },
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName="Id",
                            KeyType=KeyType.HASH
                        }
                    },
                    AttributeDefinitions= new List<AttributeDefinition>
                    {
                        new AttributeDefinition{AttributeName="Id",AttributeType=ScalarAttributeType.S}
                    }
                });
            });
        }
    }
}
