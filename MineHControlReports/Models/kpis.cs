using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MineHControlReports.Models
{
    public class kpis
    {

        public virtual Guid Id { get; set; }

        [Required]
        [Display(Name = "Kpis")]
        public virtual String Name { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public virtual String Descr { get; set; }

        [Display(Name = "Unidade")]
        public virtual  String Unity { get; set; }


        [Required]
        [Display(Name = "Token")]
        public virtual String Token { get; set; }

        public kpis()
        {
           
        }

    }

    public class kpisMap : ClassMapping<kpis>
    {
        public kpisMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.GuidComb));
            Property(x => x.Name, m =>
            {
                m.NotNullable(true);
                
            });
            Property(x => x.Descr, m =>
            {
                m.NotNullable(true);
                
               
            });

            Property(x => x.Unity, m =>
            {
                m.NotNullable(true);


            });

            Property(x => x.Token, m =>
            {
                m.NotNullable(true);


            });
        }
    }
}