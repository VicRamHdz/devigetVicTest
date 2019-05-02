using System;
using System.Threading.Tasks;
using RedditPost.Base;
using RedditPost.Models;

namespace RedditPost.Services
{
    public class TopService : ServiceBase
    {
        public async Task<ResponseResult<TopModel>> GetTop()
        {
            var endpoint = "r/subreddit/Top";
            var result = await GetAsync<TopModel>(endpoint);
            return result;
        }
    }
}
