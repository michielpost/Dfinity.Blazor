actor {
    public shared (msg) func storage() : async Principal {
        msg.caller
    };
};
