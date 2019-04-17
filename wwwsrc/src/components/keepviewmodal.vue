<template>
  <div class="keepviewmodal">
    <div id="bd-example-modal-lg" class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog"
      aria-labelledby="myLargeModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
          <div class="container-fluid">
            <div class="row">
              <div class="col-6 p-0">
                <img :src="activeKeep.img" class="img-fluid w-100">
              </div>
              <div class="col-6 d-flex flex-column justify-content-between p-0 left-border">
                <div>
                  <h2 class="mt-4 bottom-border pb-2">{{activeKeep.name}}</h2>
                  <p>{{activeKeep.description}}</p>
                </div>
                <span>
                  <span class="d-flex flex-row justify-content-center">
                    <button class="btn btn-sm btn-danger mb-3 mx-2" @click="deleteKeep(activeKeep)"><i
                        class="fas fa-ban" title="Delete keep"></i></button>
                    <div class="dropdown">
                      <button class="btn btn-secondary btn-sm dropdown-toggle mx-2" type="button"
                        id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        Add to Vault
                      </button>
                      <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                        <a v-for="vault in vaults" class="dropdown-item pointer"
                          @click="addToVault(vault)">{{vault.name}}</a>
                      </div>
                    </div>
                  </span>
                  <div class="card-footer">
                    <small><i class="far fa-eye" title="Views"></i>: {{activeKeep.views}} <i class="far fa-save ml-4"
                        title="Keeps"></i>: {{activeKeep.keeps}}<i class="fas fa-share-square ml-4 pointer"
                        title="Share"></i></small>
                  </div>
                </span>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "keepviewmodal",
    props: [],
    data() {
      return {}
    },
    computed: {
      activeKeep() {
        return this.$store.state.activeKeep
      },
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      addToVault(vault) {
        let kid = this.activeKeep.id
        this.$store.dispatch('addToVault', { vaultId: vault.id, keepId: kid })
      },
      deleteKeep(keep) {
        this.$store.dispatch('deleteKeep', keep)
        $('#bd-example-modal-lg').modal('hide');
      }
    },
    components: {}
  }
</script>

<style>
  .modal-content {
    border: 1px solid black;
    background-color: #f4f3f3;
  }

  .bottom-border {
    border-bottom: 5px solid #bfd8d5;
  }

  .left-border {
    border-left: 1px solid #bfd8d5;
  }

  .card-footer {
    background-color: #b1bed5;
    color: white;
  }
</style>