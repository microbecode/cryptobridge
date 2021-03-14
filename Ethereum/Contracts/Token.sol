pragma solidity ^0.5.17;

import "./token/ERC20/ERC20.sol";

contract Token is ERC20 {
    constructor(uint totalSupply) public {
        _mint(msg.sender, totalSupply);
    }
}