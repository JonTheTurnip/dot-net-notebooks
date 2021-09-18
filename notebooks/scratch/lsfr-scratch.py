
## https://www.youtube.com/watch?v=Ks1pw1X22y4

## 1. let's do a simple 4 bit register first

state = 0b1001

for i in range(20):
    # print("{:04b}".format(state))
    print(state & 1, end = '')
    # here we are xoring the right most bit with the bit to the left of it
    # we then 'and' with 1 to get the last bit
    newBit = (state ^ (state >> 1)) & 1
    # because when we shift our state to the right our left most bit becomes zero
    # if you 'or' a zero with something it will set that zero bit to whatever
    # the something is
    state = (state >> 1) | (newBit << 3) 

#exit()   # if you want exit the repl 

## 2. Now do a 128 bit register!

state = (1 << 127) | 1
while True:
    print(state & 1, end = '')
    # below we xor with 2nd, 3rd and 8th from right to get maximum length of cyle i.e 2^128 - 1
    newBit = (state ^ (state >> 1) ^ (state >> 2) ^ (state >> 7)) & 1
    state = (state >> 1) | (newBit << 127) 


## 3. Would be interesting to write some code to test a given number of iterations for randomness.

