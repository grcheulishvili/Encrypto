# Basic Mixed Alphabet Cipher encryption implementation

## Overview
This repository provides a C# implementation of a basic mixed alphabet cipher. This cipher is a simple substitution cipher where each letter of the plaintext is replaced by a different letter of the alphabet. The substitution is determined by a key, which is a permutation of the alphabet. 

![Encrypto simple demonstration](https://github.com/grcheulishvili/Encrypto/blob/main/Encrypto_encrypt.png)

Key is hardcoded in the source code. Hence:

## Security Considerations
While this cipher is simple to implement, it is not considered secure. It can be easily broken using frequency analysis or brute force attacks. For more secure encryption, consider using stronger cryptographic algorithms like AES or RSA.

## Further Improvements 
- Let the user define the key for a file
- Implement methods to store, retrieve, and securely manage encryption keys
- Explore different cipher modes like Electronic Codebook (ECB), Cipher Block Chaining (CBC), and Counter (CTR) to add more complexity

## License
This project is licensed under GPL 3.0

## Contributing
Feel free to contribute to this project by submitting pull requests or reporting issues.
