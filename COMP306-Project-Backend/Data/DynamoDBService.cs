﻿using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using COMP306_Project_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP306_Project_Backend.Data
{
    public class DynamoDBService
    {
        IAmazonDynamoDB dynamoDBClient { get; set; }
        AmazonDynamoDBClient client;
        DynamoDBContext context;

        public DynamoDBService(IAmazonDynamoDB dynamoDBClient)
        {
            this.dynamoDBClient = dynamoDBClient;
        }

        public async Task<Visitor> RegisterVisitor(Visitor visitor)
        {
            context = new DynamoDBContext(dynamoDBClient);
            await context.SaveAsync(visitor, default(System.Threading.CancellationToken));
            Visitor newVisitor = await context.LoadAsync<Visitor>(visitor.Email, default(System.Threading.CancellationToken));
            return visitor;
        }

    }
}
