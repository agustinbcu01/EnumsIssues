This repo demonstrates issues with PostgreSQL enums and Entity Framework.

You can see the same project using 2 different branches [dot_net_8 ](https://github.com/agustinbcu01/EnumsIssues/tree/dot-net-8) and [dot_net_10](https://github.com/agustinbcu01/EnumsIssues/tree/dot-net-10). 

migrations scripts


[Migration script .net8](https://github.com/agustinbcu01/EnumsIssues/blob/dot-net-8/EnumsIssues/all-migrations.sql)

[Migration script .net10](https://github.com/agustinbcu01/EnumsIssues/blob/dot-net-10/EnumsIssues/all-migrations.sql)

Also, this call failed

```c#
 return _context.User.Where(x => x.Status == StatusEnum.Active).Select(x => new UserModel(x)).ToArray();
```
