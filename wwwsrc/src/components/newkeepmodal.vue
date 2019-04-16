<template>
  <div class="newkeepmodal">
    <div class="modal fade" id="nkeepmodal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle"
      aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalCenterTitle">New Keep</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="createKeep">
              <input class="form-control" type="text" v-model="newKeep.Name" placeholder="Name">
              <input class="form-control mt-3" type="text" v-model="newKeep.Description" placeholder="Description">
              <input class="form-control mt-3" type="text" v-model="newKeep.Img" placeholder="Image URL">
              <button type="submit" class="btn btn-success mt-3">Create New Keep</button>
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
    name: "newkeepmodal",
    props: [],
    data() {
      return {
        newKeep: {
          Name: '',
          Description: '',
          Img: ''
        }
      }
    },
    computed: {},
    methods: {
      createKeep() {
        this.$store.dispatch('createKeep', this.newKeep)
        this.newKeep = {}
      }
    },
    components: {}
  }
</script>