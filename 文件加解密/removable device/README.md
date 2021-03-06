

#### 文件加密
对于单文件加解密，为保证加密的体验效果，单文件对象不建议超过 10 MB，如果您需要加密大文件，请使用文件夹加解密。
对于文件夹的加解密没有大小要求。

#### 文件夹加密
仅Windows有效，采用的方式是将文件夹重命名，在文件夹后面添加一个标识串，
这个串在Windows下会被认为被加密，文件夹成黄色小锁状，无法直接打开。如果
是可移动设备，在linux下是可以直接打开的。
对于文件夹加解密，请确保加解密后的文件夹与原文件夹在同一驱动下，否则文件夹的加解密将不成功，即使程序提示您操作成功。
最好是与原目录在同一个目录。

#### 特别注意

 所有可移动设备均称为U盘

 所有的文件夹加密密钥都是采用同一个密钥，新的密钥将覆盖原来的密钥，当前目录下的文件log.config是文件(文件夹)加密的密钥配置文件，
 请勿将其删除或修改，否则将导致无法解密您已加密的的文件夹。如果不小心将其删除或修改，请再设置相同的密钥对任意文件夹进行加密即可
 对原先的加密文件夹进行加密。

 请务必牢记您的加密密钥，软件本身不会记录您的密钥，对于单文件的加解密尤其重要,因为对于单文件的加解密程序不会检验您的密钥是否正确，
 错误的密钥可能会解密出意想不到的文件，可能对您的系统造成无法预料的伤害。由此造成的一切损失请用户自行承担，并且加解密成功后原文件
 并没有自动删除，这是防止用户误操作，用户请根据需要自己删除相应的文件以保证保密性。
