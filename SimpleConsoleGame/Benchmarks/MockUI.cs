using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleGame.Benchmarks;
internal class MockUI
{
    private string _message = string.Empty;
    public void AddMessage(string message)
    {
        _message = message;
    }
}
