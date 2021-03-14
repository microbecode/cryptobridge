pragma solidity ^0.5.17;

import "./token/ERC20/IERC20.sol";

contract Deposit {
    address public token;
    event Deposited(address, uint);

    constructor(address _token) public {
        token = _token;
    }

    function deposit(uint amount) public {
        IERC20(token).transferFrom(msg.sender, address(this), amount);
        emit Deposited(msg.sender, amount);
    }
}