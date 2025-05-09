﻿using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;
        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
        }
        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager = (ICacheManager)ServiceTool.ServiceProvider.GetService(typeof(ICacheManager));
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
