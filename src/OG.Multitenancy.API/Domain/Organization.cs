﻿namespace OG.Multitenancy.API.Domain
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public bool Active { get; set; }
    }
}
