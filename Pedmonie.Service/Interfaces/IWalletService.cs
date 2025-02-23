using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedmonie.Model.Entity;

namespace Pedmonie.Service.Interfaces;
public interface IWalletService
{
    Task<BaseResponse<Wallet>> GetWalletByIdAsync(Guid walletId);
}
