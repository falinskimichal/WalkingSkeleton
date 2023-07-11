namespace BlazorEcommerce.Client.Services.AddressService
{
    public interface IAddressService
    {
        Task<ServiceResponse<Address>> GetAddress();
        Task<ServiceResponse<Address>> AddOrrUpdateAddress(Address address);
    }
}
