﻿// Copyright (c) 2017 TPDT
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// 
// SimCivil - SimCivil.Test - TestServiceB.cs
// Create Date: 2018/01/07
// Update Date: 2018/12/10

using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using SimCivil.Gate;
using SimCivil.Rpc.Session;

using Xunit;

namespace SimCivil.Test
{
    class TestServiceB : ITestServiceB, ISessionRequired
    {
        public AsyncLocal<IRpcSession> Session { get; } = new AsyncLocal<IRpcSession>();

        public void SetSession(string key, string value)
        {
            Session.Value[key] = value;
        }

        public Task<string> EchoAsync(string s)
        {
            return Task.FromResult(s);
        }

        public async Task<IPEndPoint> CheckAsync()
        {
            Assert.NotNull(Session.Value);
            var session = Session.Value;
            await Task.Delay(500);
            Assert.NotNull(session);

            return session.RemoteEndPoint;
        }

        [LoginFilter]
        public void DeniedAction() { }

        public Task<(double, double)> TupleEchoAsync((double, double) dump)
        {
            return Task.FromResult(dump);
        }
    }
}