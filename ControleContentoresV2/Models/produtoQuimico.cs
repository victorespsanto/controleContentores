//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class produtoQuimico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public produtoQuimico()
        {
            this.movimentacao = new HashSet<movimentacao>();
        }
    
        public int nmProduto { get; set; }
        public string nomeProduto { get; set; }
        public int idFuncaoProduto { get; set; }
        public int idStatus { get; set; }
        public int idProduto { get; set; }
    
        public virtual funcaoProduto funcaoProduto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<movimentacao> movimentacao { get; set; }
        public virtual status status { get; set; }
    }
}
