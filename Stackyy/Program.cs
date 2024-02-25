using Stackyy;
using Stackyy.Mutations;
using Stackyy.Queries;
using Stackyy.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DataBaseService>();
builder.Services.AddSingleton<UserRepository>();
builder.Services.AddSingleton<QuestionsRepository>();


builder.Services.AddGraphQLServer()
    .AddQueryType(q => q.Name("Query"))
    .AddType<UserQuery>()
    .AddType<QuestionsQuery>()
    .AddMutationType(m=>m.Name("Mutation"))
    .AddType<UserMutation>()
    .AddType<QuestionsMutation>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
