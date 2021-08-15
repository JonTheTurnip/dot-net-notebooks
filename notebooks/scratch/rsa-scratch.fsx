open System.Security.Cryptography
open System.Text

// 1. Alice creates a new instance of RSACryptoServiceProvider to generate public and private key data.
let aliceRsa = new RSACryptoServiceProvider() // Note for fsx don't use 'use'
let aliceRsaParams = aliceRsa.ExportParameters(false) // false means don't include private key in export


// 2. Bob uses Alice's public key to encrypt his message

// a. Convert string message to bytes
let byteConverter = UnicodeEncoding()
let message = byteConverter.GetBytes("hi")


// b. 
let bobRsa = new RSACryptoServiceProvider()
bobRsa.ImportParameters(aliceRsaParams)
let encryptedMessage = bobRsa.Encrypt(message, false)

// 3. Alice decrypts Bob's message
let decryptedMessage = aliceRsa.Decrypt(encryptedMessage, false)

// 4.
byteConverter.GetString(decryptedMessage)