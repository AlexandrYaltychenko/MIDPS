#!/bin/bash
gcc scripts/hello_c.c -o scripts/hello_c
javac scripts/hello_java.java
g++ scripts/hello_c++.cpp -o scripts/hello_c++
python -m py_compile scripts/hello_python.py
rbx compile scripts/hello_ruby.rb -o scripts/hello_ruby.rbc