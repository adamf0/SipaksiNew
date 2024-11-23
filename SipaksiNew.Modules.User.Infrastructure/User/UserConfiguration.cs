using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SipaksiNew.Modules.User.Infrastructure.User
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<Domain.User.User>
    {
        public void Configure(EntityTypeBuilder<Domain.User.User> builder)
        {
            //builder.HasOne<Category>().WithMany();
        }
    }
}
