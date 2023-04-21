# MediatREvent

1.  MediatR
    builder.Services.AddMediatR(Assembly.Load("DataService"));


2.  Automapper

        var automapperConfig = new MapperConfiguration(config =>
        {
        config.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();//Camel命名与Pascal命名的兼容,配置之后会映射property_name到PropertyName
        config.DestinationMemberNamingConvention = new PascalCaseNamingConvention();
        config.AddProfile(new DataService.Profile.AutoMapperProfile());
        });
        builder.Services.AddSingleton(automapperConfig.CreateMapper());//只有一个单例


3.  BackgroundService
    builder.Services.AddHostedService&lt;MyService&gt;();

