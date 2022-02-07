using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPhone.DAL.Mapeamento
{
    public class PersonPhoneMAP : IEntityTypeConfiguration<Models.PersonPhone>
    {
        public void Configure(EntityTypeBuilder<Models.PersonPhone> builder)
        {
            builder.ToTable("TB_PERSON_PHONE");

            //Primary Key
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("PEP_CODIGO");
            builder.Property(x => x.PhoneNumber).HasColumnName("PEP_PHONE_NUMBER");
            builder.Property(x => x.IdPhoneNumberType).HasColumnName("PEP_PNTCODIGO");


            builder.HasOne(x => x.PhoneNumberType)
              .WithMany()
              .HasForeignKey(y => y.IdPhoneNumberType);
        }
    }
}
