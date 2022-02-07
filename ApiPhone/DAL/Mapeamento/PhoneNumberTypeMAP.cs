using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPhone.DAL.Mapeamento
{
    public class PhoneNumberTypeMAP : IEntityTypeConfiguration<Models.PhoneNumberType>
    {
        public void Configure(EntityTypeBuilder<Models.PhoneNumberType> builder)
        {
            builder.ToTable("TB_PHONE_NUMBER_TYPE");

            //Primary Key
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("PNT_CODIGO");
            builder.Property(x => x.Name).HasColumnName("PNT_NAME");




        }
    }
}
