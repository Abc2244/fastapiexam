using AutoMapper;
using MoneyBankService.Api.Dto;
using MoneyBankService.Domain.Entities;

namespace MoneyBankService.Api.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeo para Account
            CreateMap<AccountDto, Account>();
            CreateMap<Account, AccountDto>();

            // Mapeo para Transaction
            CreateMap<TransactionDto, Transaction>()
                .ForMember(trx => trx.AccountNumber, opt => opt.MapFrom(dto => dto.AccountNumber))
                .ForMember(trx => trx.ValueAmount, opt => opt.MapFrom(dto => dto.ValueAmount));
            CreateMap<Transaction, TransactionDto>()
                .ForMember(dto => dto.AccountNumber, opt => opt.MapFrom(trx => trx.AccountNumber))
                .ForMember(dto => dto.ValueAmount, opt => opt.MapFrom(trx => trx.ValueAmount));

            // Si tienes otros modelos y DTOs, puedes agregar más mapeos aquí.
        }
    }
}
