﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControleContentoresV2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ControleContentoresEntities : DbContext
    {
        public ControleContentoresEntities()
            : base("name=ControleContentoresEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<funcaoProduto> funcaoProduto { get; set; }
        public virtual DbSet<movimentacao> movimentacao { get; set; }
        public virtual DbSet<perfilUsuario> perfilUsuario { get; set; }
        public virtual DbSet<produtoQuimico> produtoQuimico { get; set; }
        public virtual DbSet<situacao> situacao { get; set; }
        public virtual DbSet<status> status { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<volume> volume { get; set; }
    }
}