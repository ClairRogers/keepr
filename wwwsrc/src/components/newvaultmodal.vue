<template>
  <div class="newvaultmodal">
    <div class="modal fade" id="nvaultmodal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle"
      aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalCenterTitle">New Vault</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="createVault">
              <input class="form-control" type="text" v-model="newVault.Name" placeholder="Name">
              <input class="form-control mt-3" type="text" v-model="newVault.Description" placeholder="Description">
              <button type="submit" class="btn btn-success mt-3">Create New Vault</button>
            </form>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>

<script>
  export default {
    name: "newvaultmodal",
    props: [],
    data() {
      return {
        newVault: {
          Name: '',
          Description: ''
        }
      }
    },
    computed: {},
    methods: {
      createVault() {
        this.$store.dispatch('createVault', this.newVault)
        this.newVault = {}
      }
    },
    components: {}
  }
</script>